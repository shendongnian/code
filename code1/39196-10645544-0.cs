    public interface IFoo {
        /// <summary>
        /// Initialize foo.
        /// </summary>
        /// <remarks>
        /// Classes that implement this interface must invoke this method from
        /// each of their constructors.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when instance has already been initialized.
        /// </exception>
        void Initialize(int a);
    }
    public class ConcreteFoo : IFoo {
        private bool _init = false;
        public int b;
        // Obviously in this case a default value could be used for the
        // constructor argument; using overloads for purpose of example
        public ConcreteFoo() {
            Initialize(42);
        }
        public ConcreteFoo(int a) {
            Initialize(a);
        }
        public void Initialize(int a) {
            if (_init)
                throw new InvalidOperationException();
            _init = true;
            b = a;
        }
    }
