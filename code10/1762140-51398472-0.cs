    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var lookup1 = new List<Derived> { new Derived() { Key = 1, Prop1 = "A", Prop2 = "B"} } .ToLookup(x => x.Key, x => x);
    
                var baseLookup = new BaseLookup<int, Base, Derived>(lookup1);
    
                Console.WriteLine(baseLookup[1]);
                
            }        
        }
    
        public class BaseLookup<TKey, TBase, TDerived> : ILookup<TKey, TBase> where TDerived : TBase
        {
            private readonly ILookup<TKey, TDerived> _inner;
    
            public BaseLookup(ILookup<TKey, TDerived> inner)
            {
                _inner = inner;
            }
    
            IEnumerator<IGrouping<TKey, TBase>> IEnumerable<IGrouping<TKey, TBase>>.GetEnumerator()
            {
                var flattened = _inner.SelectMany(
                    (x) => x,
                    (gr, v) => new KeyValuePair<TKey, TBase>(gr.Key, v));
    
                return (IEnumerator<IGrouping<TKey, TBase>>) flattened.GetEnumerator();
            }
    
            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable) _inner).GetEnumerator();
            }
    
            public bool Contains(TKey key)
            {
                return _inner.Contains(key);
            }
    
            public int Count => _inner.Count;
    
            public IEnumerable<TBase> this[TKey key] => _inner[key].Cast<TBase>();
        }
    
        public class Base
        {
            public int Key { get; set; }
    
            public string Prop1 { get; set; }
        }
    
        public class Derived : Base
        {
            public string Prop2 { get; set; }
        }
    }
