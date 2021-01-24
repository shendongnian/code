    class TFoo
    {
        public int foo;
    
        public static bool operator ==(TFoo a, TFoo b)
        {
            return a.Equals(b);
        }  
    
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType()
                && this.foo == ((TFoo)obj).foo;
        }
        //your code
    }
    
    
    class TBar : TFoo
    {
        public int bar;
    
        public static bool operator ==(TBar a, TBar b)
		{
			return a.Equals(b);
		}
	
		public override bool Equals(object obj)
		{
			return (obj is TBar) && this.bar == ((TBar)obj).bar && base.Equals(obj);
		}
        //your code
    }
