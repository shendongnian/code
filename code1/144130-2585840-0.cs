    public class A {
      public A() {
        Console.WriteLine("You called the first constructor");
      }
      public A(int x) {
        Console.WriteLine("You called the second constructor with " + x);
      }
    }
    public class B : A {
      public B() : base() { } // Calls the A() constructor
    }
    public class C : A {
      public C() : base(10) { } // Calls the A(int x) constructor
    }
    public class D : A {
      public D() { } // No explicit base call; Will call the A() constructor
    }
    ...
    new B(); // Will print "You called the first constructor"
    new C(); // Will print "You called the second constructor with 10"
    new D(); // Will print "You called the first constructor"
