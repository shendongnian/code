    using System;
    using System.Collections.Generic;
    using System.Collections;
    
    namespace Main
    {
        internal partial class Dictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>
        {
            internal new virtual void Add(TKey key, TValue value)
            {   
                if (!base.ContainsKey(key))
                {
                    base.Add(key, value);
                }
            }
        }
    
        internal partial class List<T> : System.Collections.Generic.List<T>
        {
            internal new virtual void Add(T item)
            {
                if (!base.Contains(item))
                {
                    base.Add(item);
                }
            }
        }
    
        public class Program
        {
            public static void Main()
            {
                Dictionary<int, string> dic = new Dictionary<int, string>();
                dic.Add(1,"b");
                dic.Add(1,"a");
                dic.Add(2,"c");
                dic.Add(1, "b");
                dic.Add(1, "a");
                dic.Add(2, "c");
    
                string val = "";
                dic.TryGetValue(1, out val);
    
                Console.WriteLine(val);
                Console.WriteLine(dic.Count.ToString());
    
    
                List<string> lst = new List<string>();
                lst.Add("b");
                lst.Add("a");
                lst.Add("c");
                lst.Add("b");
                lst.Add("a");
                lst.Add("c");
    
                Console.WriteLine(lst[2]);
                Console.WriteLine(lst.Count.ToString());
            }
        }
    }
