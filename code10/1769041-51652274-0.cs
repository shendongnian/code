    abstract class BaseClass   // Abstract class
    {
        public int X {get;set;} // property in common for 2 class
    }
    
    class A : BaseClass
    {
    }
    
    class B : BaseClass
    {
        public int Y {get;set;} // other property of B
    }
