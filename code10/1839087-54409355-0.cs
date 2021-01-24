    class CommonInterfaces
    {
        public static void DoWork()
        {
            var lst1 = new List<A>();
            var lst2 = new List<B>();
            var result = Merge<ICommon, A, B>(lst1, lst2);
        }
        public static IEnumerable<T> Merge<T, TA, TB>(IEnumerable<TA> a, IEnumerable<TB> b) where TA: T where TB: T
        {
            foreach (var itm in a)
                yield return itm;
            foreach (var itm in b)
                yield return itm;
        }
    }
    public interface ICommon { }
    public class A : ICommon { }
    public class B : ICommon { }
