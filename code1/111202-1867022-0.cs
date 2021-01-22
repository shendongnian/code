    namespace MaLio.StopWatch {
        class Program {
            static void Main(string[] args) {
    
                Container container = new Container();
                Container copy = null;
    
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = 
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    
                // may be a formatter created elsewhere
                if (formatter.SurrogateSelector == null) {
                    formatter.SurrogateSelector = new StopWatchSelector();
                }
                else {
                    formatter.SurrogateSelector.ChainSelector(new StopWatchSelector());
                }
    
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream()) {
    
                    formatter.Serialize(stream, container);
    
                    stream.Flush();
                    stream.Position = 0;
    
                    copy = formatter.Deserialize(stream) as Container;
                }
    
    
                System.Diagnostics.Debug.WriteLine(
                    "Reference Equals: " + (object.ReferenceEquals(container, copy)).ToString());
    
                System.Console.ReadKey();
            }
        }
    
        public class StopWatchSelector : System.Runtime.Serialization.SurrogateSelector {
    
            private StopWatchSurrogate _Surrogate;
    
            public StopWatchSelector() {
                _Surrogate = new StopWatchSurrogate();
            }
    
            public override System.Runtime.Serialization.ISerializationSurrogate GetSurrogate(
                System.Type type, 
                System.Runtime.Serialization.StreamingContext context,
                out System.Runtime.Serialization.ISurrogateSelector selector) {
    
                System.Runtime.Serialization.ISerializationSurrogate surrogate;
    
                surrogate = base.GetSurrogate(type, context, out selector);
    
                if (surrogate == null) {
                    if (type == typeof(System.Diagnostics.Stopwatch)) {
                        surrogate = _Surrogate;
                    }
                }
    
                return surrogate;
            }
        }
    
        public class StopWatchSurrogate : System.Runtime.Serialization.ISerializationSurrogate {
    
            private const string NULL_INDICATOR_STRING = @"__StopWatchNull";
    
            // the invalid contexts as an example
            private const System.Runtime.Serialization.StreamingContextStates INVALID_CONTEXTS =
                System.Runtime.Serialization.StreamingContextStates.CrossMachine | 
                System.Runtime.Serialization.StreamingContextStates.Remoting;
    
            public void GetObjectData(
                object obj, 
                System.Runtime.Serialization.SerializationInfo info, 
                System.Runtime.Serialization.StreamingContext context) {
    
                System.Diagnostics.Stopwatch stopWatch = obj as System.Diagnostics.Stopwatch;
    
                if (stopWatch == null) {
                    info.AddValue(NULL_INDICATOR_STRING, true);
                }
                else {
                    info.AddValue(NULL_INDICATOR_STRING, false);
    
                    // add other values looked up via reflection
                }
            }
    
            public object SetObjectData          (
                object obj,
                System.Runtime.Serialization.SerializationInfo info, 
                System.Runtime.Serialization.StreamingContext context, 
                System.Runtime.Serialization.ISurrogateSelector selector) {
    
                System.Diagnostics.Stopwatch stopWatch = null;
                bool isNull = info.GetBoolean(NULL_INDICATOR_STRING);
    
                if (!isNull) {
                    stopWatch = obj as System.Diagnostics.Stopwatch;
                    // read other values and set via reflection
                }
    
                return stopWatch;
            }
    
            private void CheckContext(System.Runtime.Serialization.StreamingContext context) {
    
                if ((context.State & INVALID_CONTEXTS) != 0) {
                    throw new System.NotSupportedException();
                }
            }
        }
    
        [System.Serializable]
        public class Container {
    
            private System.Diagnostics.Stopwatch _Watch = new System.Diagnostics.Stopwatch();
        }
    }
