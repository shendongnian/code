        interface IFoo
	{
	    Type FooType { get; set; }
	    string Name { get; set; }
	}
	class FooWithValue<T> : IFoo
	{
            //Setter is available, but useless if used to determine T and set publicly
	    Type _fooType = typeof(T);
	    public Type FooType
            { 
                get { return _fooType; }
                set { _fooType = value; }
            }
	    public string Name { get; set; }
	    public T Value { get; set; }
	}
