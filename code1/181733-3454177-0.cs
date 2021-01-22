    public class DocketType : Enumeration<DocketType, int, string>
    {
        public static readonly DocketType Withdrawal =
            new DocketType(2, "Withdrawal");
        public static readonly DocketType Installation =
            new DocketType(3, "Installation");
        private DocketType(int docketTypeId, string description)
            : base(docketTypeId, description) { }
    }
    public abstract class Enumeration<TEnum, TId, TDescription> : IComparable
        where TEnum : Enumeration<TEnum, TId, TDescription>
    {
        private static readonly Dictionary<TId, TEnum> _cache =
            new Dictionary<TId, TEnum>();
        public TId Id { get; private set; }
        public TDescription Description { get; private set; }
        protected Enumeration(TId id, TDescription description)
        {
            Id = id;
            Description = description;
        }
        public static TEnum Resolve(TId id)
        {
            TEnum value;
            if (!_cache.TryGetValue(id, out value))
            {
                Type t = typeof(TEnum);
                value = t.GetFields(BindingFlags.Public | BindingFlags.Static)
                         .Where(f => f.FieldType == t)
                         .Select(f => (TEnum)f.GetValue(null))
                         .Where(e => e.Id.Equals(id))
                         .Single();
                _cache[id] = value;
            }
            return value;
        }
        // IComparable
        public int CompareTo(object obj)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
