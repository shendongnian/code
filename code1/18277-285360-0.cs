        class FooContainer
        {
            private ICollection<Foo> foos;
            public ReadOnlyCollection<Foo> ReadOnlyFoos { get { return foos.ToList<Foo>().AsReadOnly();} }
    
        }
