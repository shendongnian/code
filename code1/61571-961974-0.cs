    class B { }
    class A : B { }
    interface I<T> where T : B
    {
        T TheObject { get; set; }
    }
    class C : I<A>
    {
        public A TheObject { get; set; }
    }
