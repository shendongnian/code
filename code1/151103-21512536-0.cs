    public class Outer
    {
        private interface IPrivateFactory<T>
        {
            T CreateInstance();
        }
        public sealed class Nested
        {
            private Nested() {
                // private constructor, accessible only to the class Factory.
            }
            public class Factory : IPrivateFactory<Nested>
            {
                Nested IPrivateFactory<Nested>.CreateInstance() { return new Nested(); }
            }
        }
        public Nested GetNested() {
            // We couldn't write these lines outside of the `Outer` class.
            IPrivateFactory<Nested> factory = new Nested.Factory();
            return factory.CreateInstance();
        }
    }
