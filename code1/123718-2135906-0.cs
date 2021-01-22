    class SomeClass { }
    public class A<T> : IEnumerable<T>
    {
        
        public T this[int index]
        {
            get
            {
                return (this[index]);
            }
        }
        public T this[String index]
        {
            get
            {
                return (this[index]);
            }
        }
    }
    public class B : A<SomeClass>
    {
        public B this[char typeToFilter]
        {
            get
            {
                return new B();
            }
        }
    }
            B classList = new B();
            SomeClass test = classList[0];
