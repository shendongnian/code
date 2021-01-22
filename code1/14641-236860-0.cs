    using System;
    using System.Collections.Generic;
    
    public class Test
    {
        public FakeIndexedPropertyInCSharp DictionaryElement { get; set; }
    
        public Test()
        {
            DictionaryElement = new FakeIndexedPropertyInCSharp();
        }
    
        public class FakeIndexedPropertyInCSharp
        {
            private Dictionary<string, object> m_Dictionary = new Dictionary<string, object>();
    
            public object this[string index]
            {
                get 
                {
                    object result;
                    return m_Dictionary.TryGetValue(index, out result) ? result : null;
                }
                set 
                {
                    m_Dictionary[index] = value; 
                }
            }
        }
    
    
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.DictionaryElement["hello"] = "world";
            Console.WriteLine(t.DictionaryElement["hello"]);
        }
    }
