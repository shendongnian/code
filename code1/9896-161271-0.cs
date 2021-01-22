    class Base
    {
      private Base() { }
      public Base(int x) {}
    }
    
    class Derived : Base
    {
      //public Derived() { } won't compile because Base() is private
      public Derived(int x) :base(x) {}
      public Derived() : base (0) {} // still works because you are giving a value to base
    }
