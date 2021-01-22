    public class Repository<T>
    {
        protected static TextReader FileName { get; set; }
        public static TCollection List<TCollection>()
        {
            var ser = new XmlSerializer(typeof (TCollection));
            return (TCollection) ser.Deserialize(FileName);
        }
        public static TItem Single<TItem, TCollection>(Predicate<TItem> expression) 
            where TCollection : IDisposable, IEnumerable<TItem>
        {
            using (var list = List<TCollection>())
            {
                return list.Single(item => expression(item));
            }
        }
    }
