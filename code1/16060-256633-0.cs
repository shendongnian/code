    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace Reflection
    {
        class SomeClass
        {
            private string StringPrimer = "The parameter text is: ";
            public SomeClass(string text)
            {
                 Console.WriteLine(StringPrimer + text);
            }
            public string getPrimer() //supplies the Primer in upper case, just for kicks
            {
                return StringPrimer.ToUpper();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                SomeClass s = new SomeClass("this is an example of the classes normal hard-coded function.\nNow try feeding in some text");
                string t = Console.ReadLine();
    
                Console.WriteLine("Now feed in the class name (SomeClass in this case)");
                Type myType = Type.GetType("Reflection."+Console.ReadLine()); //Stores info about the class.
                object myClass = Activator.CreateInstance(myType, new object[] { t }); //This dynamically calls SomeClass and sends in the text you enter as a parameter
    
                //Now lets get the string primer, using the getPrimer function, dynamically
                string primer = (string)myType.InvokeMember("getPrimer",
                                                            BindingFlags.InvokeMethod | BindingFlags.Default,
                                                            null,
                                                            myClass,
                                                            null); //This method takes the name of the method, some Binding flags,
                                                                  //a binder object that I left null,
                                                                  //the object that the method will be called from (would have been null if the method was static)
                                                                  //and an object array of parameters, just like in the CreateInstance method.
                Console.WriteLine(primer);
            }
        }
    }
