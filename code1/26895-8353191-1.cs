    // E is the derived type-safe-enum class
    // - this allows all static members to be truly unique to the specific
    //   derived class
    public class EnumBase<E, T> where E: EnumBase<E, T>
    {
        #region Instance code
        public T Value { get; private set; }
        public string Name { get; private set; }
        protected EnumBase(T EnumValue, string Name)
        {
            Value = EnumValue;
            this.Name = Name;
            mapping.Add(Name, this);
        }
        public override string ToString() { return Name; }
        #endregion
        #region Static tools
        static private readonly Dictionary<string, EnumBase<E, T>> mapping;
        static EnumBase() { mapping = new Dictionary<string, EnumBase<E, T>>(); }
        protected static E Parse(string name)
        {
            EnumBase<E, T> result;
            if (mapping.TryGetValue(name, out result))
            {
                return (E)result;
            }
            throw new InvalidCastException();
        }
        // This is protected to force the child class to expose it's own static
        // method.
        // By recreating this static method at the derived class, static
        // initialization will be explicit, promising the mapping dictionary
        // will never be empty when this method is called.
        protected static IEnumerable<E> All
        { get { return mapping.Values.AsEnumerable().Cast<E>(); } }
        #endregion
    }
