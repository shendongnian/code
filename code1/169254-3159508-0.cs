    public class ThingHolderDataAccess
    {
        public ThingHolder GetThingHolderForSomeArgs(int arg1, int arg2)
        {
            var oneThings = GetOneThings(arg1);
            var otherThings = GetOtherThings(arg2);
            return new ThingHolder(oneThings, otherThings);
        }
        private IEnumerable<OneThing> GetOneThings(int arg)
        {
            //...
            return new List<OneThing>();
        }
        private IEnumerable<AnotherThing> GetOtherThings(int arg2)
        {
            //...
            return new List<AnotherThing>();
        }
    }
    
    public class ThingHolder
    {
        public IIndexedReadonlyCollection<OneThing> OneThings
        {
            get;
            private set;
        }
        public IIndexedReadonlyCollection<AnotherThing> OtherThings
        {
            get;
            private set;
        }
        public ThingHolder(IEnumerable<OneThing> oneThings,
                           IEnumerable<AnotherThing> otherThings)
        {
            OneThings = oneThings.ToIndexedReadOnlyCollection();
            OtherThings = otherThings.ToIndexedReadOnlyCollection();
        }
    }
    #region These classes can be written once, and used everywhere
    public class IndexedReadonlyCollection<T> 
        : List<T>, IIndexedReadonlyCollection<T>
    {
        public IndexedReadonlyCollection(IEnumerable<T> items)
            : base(items)
        {
        }
    }
    public static class EnumerableExtensions
    {
        public static IIndexedReadonlyCollection<T> ToIndexedReadOnlyCollection<T>(
            this IEnumerable<T> items)
        {
            return new IndexedReadonlyCollection<T>(items);
        }
    }
    public interface IIndexedReadonlyCollection<out T> : IEnumerable<T>
    {
        T this[int i] { get; }
    }
    #endregion
