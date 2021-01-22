    abstract class AbstractClass<TDerivedClass>
        where TDerivedClass : AbstractClass<TDerivedClass>
    {
        Col<TDerivedClass> parent;
        public AbstractClass(Col<TDerivedClass> parent)
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
