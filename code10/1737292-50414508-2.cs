    public interface FooFactory : IGenericFactory<Foo, FooEnum> {
        IGenericFactory<Foo, FooEnum> Wrapped { get; }
        // The "magic" - Note that magic always makes your code harder to understand...
        public static implicit operator FooFactory(IGenericFactory<Foo, FooEnum> wrapped) {
            // I think this can be placed here. If C# won't let you add this
            // implicit operator here, then you can easily implement this factory
            // method as an extension on IGenericFactory<Foo, FooEnum>
            return new FooFactoryWrapper(wrapped);
        }
        public static implicit operator IGenericFactory<Foo, FooEnum>(FooFactory wrapper) {
            return wrapper.Wrapped;
        }
        // I'm pretty sure we can hide this implementation here in the interface,
        // but again, my C# is pretty rusty, so you may have to move this
        // and/or change the visibility
        private class FooFactoryWrapper : FooFactory {
    
            public IGenericFactory<Foo, FooEnum> Wrapped { get; private set; }
    
            public FooFactoryWrapper(IGenericFactory<Foo, FooEnum> wrapped) {
                this.wrapped = wrapped;
            }
            // Since the "friendly type" is still an instance of the base type,
            // you'll still have to fully implement that interface. Just delegate
            // all calls to your wrapped type (most useless Decorator ever)
            public Foo Make() { return Wrapped.Make(); } // sample method in IGenericFactory<>
        }
    }
