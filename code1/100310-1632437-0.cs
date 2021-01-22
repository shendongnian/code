    using System;
    using System.Collections;
    using System.Collections.Generic;
    static class Program
    {
        class MyEnumerator<TKey,TValue> : IDictionaryEnumerator, IDisposable
        {
            readonly IEnumerator<KeyValuePair<TKey, TValue>> impl;
            public void Dispose() { impl.Dispose(); }
            public MyEnumerator(IDictionary<TKey, TValue> value)
            {
                this.impl = value.GetEnumerator();
            }
            public void Reset() { impl.Reset(); }
            public bool MoveNext() { return impl.MoveNext(); }
            public DictionaryEntry Entry { get { var pair = impl.Current;
                return new DictionaryEntry(pair.Key, pair.Value);} }
            public object Key { get { return impl.Current.Key; } }
            public object Value { get { return impl.Current.Value; } }
            public object Current {get {return Entry;}}
        }
        static IDictionaryEnumerator GetBasicEnumerator<TKey,TValue>(
            this IDictionary<TKey, TValue> data)
        {
            return new MyEnumerator<TKey, TValue>(data);
        }
        static void Main()
        {
            IDictionary<int, string> data = new Dictionary<int, string>()
            {
                {1,"abc"}, {2,"def"}
            };
            IDictionaryEnumerator basic;
            using ((basic = data.GetBasicEnumerator()) as IDisposable)
            {
                while (basic.MoveNext())
                {
                    Console.WriteLine(basic.Key + "=" + basic.Value);
                }
            }
        }
    }
