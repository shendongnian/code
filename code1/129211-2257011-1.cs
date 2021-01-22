    class A      { ... }
    class B : A  { ... }
    class C : B  { ... }
    ...
    C c = new C();
    B bc = (B)c;    // <-- will work just fine without multiple inheritance
    A ac = (A)c;    // <-- ditto
