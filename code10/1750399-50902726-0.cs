    using System;
    using System.Collections.Concurrent;
    
    public class Program
    {
    	public class NestedDictionary<TK1, TK2, TK3, TValue>
    	{
    		private readonly ConcurrentDictionary<Tuple<TK1, TK2, TK3>, TValue> storage = new ConcurrentDictionary<Tuple<TK1, TK2, TK3>, TValue>();
    		public TValue this[TK1 key1, TK2 key2, TK3 key3]
    		{
    			get => this.storage[new Tuple<TK1, TK2, TK3>(key1, key2, key3)];
    			set => this.storage[new Tuple<TK1, TK2, TK3>(key1, key2, key3)] = value;
    		}
    
    		public bool TryGetValue(TK1 key1, TK2 key2, TK3 key3, out TValue value)
    		{
    			return this.storage.TryGetValue(new Tuple<TK1, TK2, TK3>(key1, key2, key3), out value);
    		}
    
    		public bool TryAdd(TK1 key1, TK2 key2, TK3 key3, TValue value)
    		{
    			return this.storage.TryAdd(new Tuple<TK1, TK2, TK3>(key1, key2, key3), value);
    		}
            // etc etc
    	}
    
    	public static void Main()
    	{
    		NestedDictionary<int, bool, DateTime, string> d = new NestedDictionary<int, bool, DateTime, string>();
    		d[1, false, new DateTime(2018, 6, 18)] = "Hello";
    		d[1, true, new DateTime(2018, 6, 18)] = "World";
    		d[2, false, new DateTime(2018, 6, 18)] = "Foo";
    		d[2, false, new DateTime(2018, 6, 19)] = "Bar";
    		Console.WriteLine(d[1, true, new DateTime(2018, 6, 18)]); // World
    	}
    }
