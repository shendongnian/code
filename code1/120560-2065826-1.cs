    class base     { public void  foo() { Console.write("base.foo"); } }
    class derived  { public new void foo() { Console.write("derived.foo"); } }
    base b = new base();
    b.foo()  // prints "base.foo" // no issue b is a base and variable is a base
    base b = new derived();
    b.foo(); // prints "base.foo" because variable b is base. 
    derived d = b as derived;
    d.foo()    //  prints "derived.foo" - now variable d is declared as derived. 
  
