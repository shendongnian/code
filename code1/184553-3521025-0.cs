        public abstract class DomainObj<T> // T - derived type
            where T : DomainObj<T>
        {
            public bool Meets(Func<T, bool> specification)
            {
                return specification.Invoke((T) this);
            }
        }
        public class Foo : DomainObj<Foo> {}
        public class Bar : DomainObj<Bar> {}       
        {
            Func<Foo, bool> foospec = x => true;
            Func<Bar, bool> barspec = x => true;
            var foo = new Foo();
            var bar = new Bar();
            foo.Meets(foospec);
            foo.Meets(barspec); // won't compile because of mismatched types of spec and object instance
        }
