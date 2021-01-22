    class Base {
       public virtual void Foo() {}
    }
    class Derived : Base {
       void Bar() { base.Foo(); }
    }
