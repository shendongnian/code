    // Copyright © 2007 John M Rusk (http://www.agilekiwi.com)
    // 
    // You may use this source code in any manner you wish, subject to 
    // the following conditions:
    //
    // (a) The above copyright notice and this permission notice shall be
    //     included in all copies or substantial portions of the Software.
    //
    // (b) THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    //     EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
    //     OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    //     NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
    //     HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    //     WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    //     FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    //     OTHER DEALINGS IN THE SOFTWARE.
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Soap;
    
    namespace AgileKiwi.PersistentIterator.Demo
    {
        /// <summary>
        /// This is the class we will enumerate over
        /// </summary>
        [Serializable]
        public class SimpleEnumerable
        {
            public IEnumerator<string> Foo()
            {
                yield return "One";
                yield return "Two";
                yield return "Three";
            }
    
            #region Here is a more advanced example
            // This shows that the solution even works for iterators which call other iterators
            // See SimpleFoo below for a simpler example
            public IEnumerator<string> AdvancedFoo()
            {
                yield return "One";
                foreach (string s in Letters())
                    yield return "Two " + s;
                yield return "Three";
            }
    
            private IEnumerable<string> Letters()
            {
                yield return "a";
                yield return "b";
                yield return "c";
            }
            #endregion
        }
    
        /// <summary>
        /// This is the command-line program which calls the iterator and serializes the state
        /// </summary>
        public class Program
        {
            public static void Main()
            {
                // Create/restore the iterator
                IEnumerator<string> e;
                if (File.Exists(StateFile))
                    e = LoadIterator();
                else
                    e = (new SimpleEnumerable()).Foo(); // start new iterator
    
                // Move to next item and display it.
                // We can't use foreach here, because we only want to get ONE 
                // result at a time.
                if (e.MoveNext())
                    Console.WriteLine(e.Current);
                else
                    Console.WriteLine("Finished.  Delete the state.xml file to restart");
    
                // Save the iterator state back to the file
                SaveIterator(e);
    
                // Pause if running from the IDE
                if (Debugger.IsAttached)
                {
                    Console.Write("Press any key...");
                    Console.ReadKey();
                }
            }
    
            static string StateFile
            {
                get {
                    return Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                        "State.xml");
                }
            }
        
            static IEnumerator<string> LoadIterator()
            {
                using (FileStream stream = new FileStream(StateFile, FileMode.Open))
                {
                    ISurrogateSelector selector = new EnumerationSurrogateSelector();
                    IFormatter f = new SoapFormatter(selector, new StreamingContext());
                    return (IEnumerator<string>)f.Deserialize(stream);
                }
            }
    
            static void SaveIterator(IEnumerator<string> e)
            {
                using (FileStream stream = new FileStream(StateFile, FileMode.Create))
                {
                    ISurrogateSelector selector = new EnumerationSurrogateSelector();
                    IFormatter f = new SoapFormatter(selector, new StreamingContext());
                    f.Serialize(stream, e);
                }
                #region Note: The above code puts the name of the compiler-generated enumerator class...
                // into the serialized output.  Under what circumstances, if any, might a recompile result in
                // a different class name?  I have not yet investigated what the answer might be.
                // I suspect MS provide no guarantees in that regard.
                #endregion
            }
        }
    
        #region Helper classes to serialize iterator state
        // See http://msdn.microsoft.com/msdnmag/issues/02/09/net/#S3 
        class EnumerationSurrogateSelector : ISurrogateSelector
        {
            ISurrogateSelector _next;
    
            public void ChainSelector(ISurrogateSelector selector)
            {
                _next = selector;
            }
    
            public ISurrogateSelector GetNextSelector()
            {
                return _next;
            }
    
            public ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector selector)
            {
                if (typeof(System.Collections.IEnumerator).IsAssignableFrom(type))
                {
                    selector = this;
                    return new EnumeratorSerializationSurrogate();
                }
                else
                {
                    //todo: check this section
                    if (_next == null)
                    {
                        selector = null;
                        return null;
                    }
                    else
                    {
                        return _next.GetSurrogate(type, context, out selector);
                    }
                }
            }
        }
    
        // see http://msdn.microsoft.com/msdnmag/issues/02/09/net/#S3
        class EnumeratorSerializationSurrogate : ISerializationSurrogate
        {
            public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
            {
                foreach(FieldInfo f in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                    info.AddValue(f.Name, f.GetValue(obj));
            }
    
            public object SetObjectData(object obj, SerializationInfo info, StreamingContext context,
                                        ISurrogateSelector selector)
            {
                foreach (FieldInfo f in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                    f.SetValue(obj, info.GetValue(f.Name, f.FieldType));
                return obj;
            }
        }
        #endregion
    }
