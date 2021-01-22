    using System;
    using System.Collections.ObjectModel;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                SomeClass.TellMeAboutYourself();
            }
        }
        public class Identifiers : Attribute
        {
            private string[] names;
            public Identifiers(string[] someNames)
            {
                names = someNames;
            }
            public ReadOnlyCollection<string> Names { get { return new ReadOnlyCollection<string>(names); } }
        }
        [Identifiers(new string[] {"Bill", "Ben", "Ted"})]
        static class SomeClass
        {
            public static void TellMeAboutYourself()
            {
                Identifiers theAttribute = (Identifiers)Attribute.GetCustomAttribute(typeof(SomeClass), typeof(Identifiers));
                foreach (var s in theAttribute.Names)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
 
