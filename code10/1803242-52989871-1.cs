    public static SiloExtensions
    {
        public static Silo Up(this Silo current, IEnumerable<Silo> collection)
        {
            return collection.FirstOrDefault((it) => it.ParentKey == it.Key);
        }
    }
