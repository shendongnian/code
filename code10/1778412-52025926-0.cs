    using System;
    using System.Collections.Generic;
    
    namespace MainClass
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                DictionaryList<string, int> dict = new DictionaryList<string, int>();
    
                dict.Add("assd", 45);
                dict.Add("gh", 78);
                dict.Add("uih", 235);
                dict.Add("sdfg", 345);
                dict.Add("jkl", 456);
                dict.Add("wer", 345);
                dict.Add("dfg", 454);
                dict.Add("we", 490895);
                dict.Add("dfgq", 78);
                dict.Add("jkel", 34);
                dict.Add("wepr", 1);
                dict.Add("zer", 345);
                dict.Add("kt", 345);
                dict.Add("qrk", 345);
    
    
                dict.RemoveMinimum();
                dict.Remove("wer");
    
            }
           
        }
    
        public class DictionaryList<Key, Value> : Dictionary<Key, Value> where Value : IComparable where Key : IComparable
        {
            private class MinComparer<Key1, Value1> : IComparer<KeyValuePair<Key1, Value1>> where Value1 : IComparable where Key1:IComparable
            {
                public int Compare(KeyValuePair<Key1, Value1> x, KeyValuePair<Key1, Value1> y)
                {
                    int comp = x.Value.CompareTo(y.Value);
                    if (comp == 0)
                    {
                        return x.Key.CompareTo(y.Key);
                    }
                    return comp;
                }
            }
    
            private List<KeyValuePair<Key, Value>> shadowList = new List<KeyValuePair<Key, Value>>();
            private MinComparer<Key, Value> mc = new MinComparer<Key, Value>();
    
            public new void Add(Key key, Value value)
            {
                base.Add(key, value);
    
                KeyValuePair<Key, Value> shadow = new KeyValuePair<Key, Value>(key, value);
                int index = shadowList.BinarySearch(shadow, mc);
                if (index < 0) index = ~index;
                shadowList.Insert(index, shadow);
            }
    
            public void RemoveMinimum()
            {
                if (shadowList.Count > 0)
                {
                    this.Remove(shadowList[0].Key);
                }
            }
    
            public new void Remove(Key key)
            {
                Value shadow = this[key];
                base.Remove(key);
    
                KeyValuePair<Key, Value> dummy = new KeyValuePair<Key, Value>(key, shadow);
                
                int index = shadowList.BinarySearch(dummy, mc);
    
                shadowList.RemoveAt(index);
                
            }
        }
     }
