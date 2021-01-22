    abstract class AbstractClass<DerivedClass> where DerivedClass :  AbstractClass<DerivedClass> {
        Col<DerivedClass> parent;
        public AbstractClass(Col<DerivedClass> parent)
        {
            // do stuff
            this.parent = parent;
        }
    }
    class A : AbstractClass<A>
    { 
        public A(Col<A> parent)
            :base(parent) {}
    }
    class B : AbstractClass<B>
    { 
        public A(Col<B> parent)
            :base(parent) {}
    }
