    class BaseA { virtual ~BaseA(); virtual void foo(); };
    class BaseB { virtual ~BaseB(); virtual int foo(); };
    class DerivedA : public BaseA { void foo() override; };
    class DerivedB : public BaseB { int foo() override; };
    class Derived : public DerivedA, public DerivedB { };
