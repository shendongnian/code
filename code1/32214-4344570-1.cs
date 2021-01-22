    class Base
    {
        protected Base()
        {
        }
    }
    
    class Derived : Base
    {
        public Derived() : base() // Still allowed in VS 2005
        {
        }
    	
        public void Main()
        {
            Base b = new Base(); // Allowed in VS 2003, but error in VS 2005
        }
    }
