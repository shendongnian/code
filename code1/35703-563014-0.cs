    class Foo
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }
    class Bar<T> : Foo
    {
    	public T Value { get; set; }
    
    	public Bar()
    	{
    		base.Type = typeof( T );
    	}
    }
