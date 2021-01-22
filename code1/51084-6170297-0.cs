    public abstract class Foo: IEnumerable {
        IEnumerator IEnumerable.GetEnumerator() { 
            return getEnumerator();    
        }
        protected abstract IEnumerator getEnumerator(); 
    }
    public class Foo<T>: Foo, IEnumerable<T> {
        private IEnumerable<T> ie;
        public Foo(IEnumerable<T> ie) {
            this.ie = ie;
        }
        
        public IEnumerator<T> GetEnumerator() {
            return ie.GetEnumerator();
        }
        protected override IEnumerator getEnumerator() {
 	        return GetEnumerator();
        }
        //explicit IEnumerable.GetEnumerator() is "inherited"
    }
