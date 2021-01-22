    public abstract class DynamicEnum<T> : IEquatable<T>, IComparable<T>
        where T : DynamicEnum<T>, new()
    {
        #region Instance
        public int PathCode { get; private set; }
        public string PathValue { get; private set; }
        protected DynamicEnum() { }
        protected DynamicEnum(int pathCode, string pathValue)
        {
            PathCode = pathCode;
            PathValue = PathValue;
        }
        #region IEquatable<AreaStatus> Members
        public bool Equals(T other)
        {
            return PathCode == other.PathCode;
        }
        #endregion
        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }
        public override int GetHashCode()
        {
            return PathCode.GetHashCode();
        }
        #region IComparable<AreaStatus> Members
        public int CompareTo(T other)
        {
            return PathCode.CompareTo(other.PathCode);
        }
        #endregion
        #endregion
        #region Class / Static
        static DynamicEnum()
        {
            // Despite appearances, static methods are not really inherited by
            // child classes. This means when the mapping fields below are accessed
            // by an implementing class the CLR does not see it as a method on that
            // class. In the event that the implementing class's static constructor
            // hasn't been called yet, it will not be called at that point since
            // technically no static method/property or instance of the implementing
            // class has been used. Working around this by creating an instance here
            // which causes the derived class's static constructor to be called
            // beforehand. This could alternately be solved by moving the default 'enum'
            // value initialization out of the implementing classes to the Global.asax 
            // where the database 'enum' values are optionally loaded.
            new T();
        }
        public static void Initialize(IEnumerable<T> statuses)
        {
            IntoDomainMapping = statuses.ToDictionary(x => x.PathValue, x => x);
            IntoDBMapping = IntoDomainMapping.ToDictionary(x => x.Value, x => x.Key);
        }
        public static Dictionary<string, T> IntoDomainMapping { get; protected set; }
        public static Dictionary<T, string> IntoDBMapping { get; protected set; }
        #endregion
        #region Operator Overloads
        public static bool operator ==(DynamicEnum<T> s1, T s2)
        {
            return s1.Equals(s2);
        }
        public static bool operator !=(DynamicEnum<T> s1, T s2)
        {
            return !s1.Equals(s2);
        }
        public static bool operator >(DynamicEnum<T> s1, T s2)
        {
            return s1.CompareTo(s2) > 0;
        }
        public static bool operator <(DynamicEnum<T> s1, T s2)
        {
            return s1.CompareTo(s2) < 0;
        }
        public static bool operator >=(DynamicEnum<T> s1, T s2)
        {
            return s1.CompareTo(s2) >= 0;
        }
        public static bool operator <=(DynamicEnum<T> s1, T s2)
        {
            return s1.CompareTo(s2) <= 0;
        }
        #endregion
    }
