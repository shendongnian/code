        public abstract class DomainObj
        {
        }
        public static class DomainObjExtensions
        {
            public static bool Meets<T>(this T obj, Func<T, bool> f)
                where T : DomainObj
            {
                return f(obj);
            }
        }
        public class Foo : DomainObj {}
        public class Bar : DomainObj {}
        Func<Foo, bool> foospec = x => true;
        Func<Bar, bool> barspec = x => true;
        var foo = new Foo();
        var bar = new Bar();
        foo.Meets(foospec);
        foo.Meets(barspec); // error
