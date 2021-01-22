    	class SomeClass<T>
    	{
    	}
    
    	class C
    	{
    		void Add<T>(SomeClass<T> item)
    		{
    			Type type = typeof(SomeClass<T>);
    			if (!list.ContainsKey(type))
    				list[type] = new List<SomeClass<T>>();
    			var l = (List<SomeClass<T>>)list[type];
    			l.Add(item);
    		}
    
    		public void Method<T>(SomeClass<T> obj)
    		{
    			Add(obj);
    		}
    		readonly Dictionary<Type, object> list = new Dictionary<Type, object>();
    	}
