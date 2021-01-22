    public abstract class RichEnum<TValue, TDerived> : EquatableBase<TDerived>
        where TValue : struct, IComparable<TValue>, IEquatable<TValue>
        where TDerived : RichEnum<TValue, TDerived>
    {
        // Enforcing that the field Name (´SomeEnum.SomeEnumValue´) is the same as its 
        // instances ´SomeEnum.Name´ is done by the static initializer of this class.
        // Explanation of initialization sequence:
        // 1. the static initializer of ´RichEnum<TValue, TDerived>´ reflects TDervied and 
        //    creates a list of all ´public static TDervied´ fields:
        //   ´EnumInstanceToNameMapping´
        // 2. the static initializer of ´TDerive´d assigns values to these fields
        // 3. The user is now able to access the values of a field.
        //    Upon first access of ´TDervied.Name´ we search the list 
        //    ´EnumInstanceToNameMapping´ (created at step 1) for the field that holds
        //    ´this´ instance of ´TDerived´.
        //    We then get the Name for ´this´ from the FieldInfo
        private static readonly IReadOnlyCollection<EnumInstanceReflectionInfo> 
                                EnumInstanceToNameMapping = 
            typeof(TDerived)
                .GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)
                .Where(t => t.FieldType == typeof(TDerived))
                .Select(fieldInfo => new EnumInstanceReflectionInfo(fieldInfo))
                .ToList();
        private static readonly SortedList<TValue, TDerived> Values =
            new SortedList<TValue, TDerived>();
        public readonly TValue Value;
        private readonly Lazy<string> _name;
        protected RichEnum(TValue value)
        {
            Value = value;
            // SortedList doesn't allow duplicates so we don't need to do
            // duplicate checking ourselves
            Values.Add(value, (TDerived)this);
            _name = new Lazy<string>(
                        () => EnumInstanceToNameMapping
                             .First(x => ReferenceEquals(this, x.Instance))
                             .Name);
        }
        public string Name
        {
            get { return _name.Value; }
        }
        public static implicit operator TValue(RichEnum<TValue, TDerived> richEnum)
        {
            return richEnum.Value;
        }
        public static TDerived Convert(TValue value)
        {
            return Values[value];
        }
        protected override bool Equals(TDerived other)
        {
            return Value.Equals(other.Value);
        }
        protected override int ComputeHashCode()
        {
            return Value.GetHashCode();
        }
        private class EnumInstanceReflectionInfo
        {
            private readonly FieldInfo _field;
            private readonly Lazy<TDerived> _instance;
            public EnumInstanceReflectionInfo(FieldInfo field)
            {
                _field = field;
                _instance = new Lazy<TDerived>(() => (TDerived)field.GetValue(null));
            }
            public TDerived Instance
            {
                get { return _instance.Value; }
            }
            public string Name { get { return _field.Name; } }
        }
    }
