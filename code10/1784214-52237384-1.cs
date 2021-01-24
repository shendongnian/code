    A a = new A(); // cannot instantiate interface A
    B b = new B(); // OK because B is a normal class
    A ab = new B(); // B can be instantiated for aforementioned reasons, but cannot be
                    // assigned to A because they are unrelated types
    B ba = new A(); // cannot instantiate interface A. A also cannot be assigned to
                    // B because they are unrelated.
    C c = new C(); // cannot instantiate abstract class C
    D d = new D(); // OK, D is a normal class. It is sealed, but that just means no 
                   // class can derive from it, nothing to do with instantiation
    E e = new E(); // OK, E is a normal class
    F af = new A(); // cannot instantiate interface A
    A fa = new F(); // F is a normal class, and is assignable to A because F implements A
    G g = new G(); // OK, G is a normal class
