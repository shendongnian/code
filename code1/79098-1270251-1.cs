    public class DynamicComparer<T>
        : IComparer<string>
        , IEqualityComparer<string>
    {
        private static readonly DynamicComparer<T> defaultComparer = new DynamicComparer<T>();
        private static readonly DynamicComparer<T> defaultNoThrowComparer = new DynamicComparer<T>(false);
        private DynamicComparerHelper.TryParseDelegate<T> parser = DynamicComparerHelper.GetParser<T>();
        private IComparer<T> comparer;
        private bool throwOnError;
        public DynamicComparer()
            : this(Comparer<T>.Default, true)
        {
        }
        public DynamicComparer(bool throwOnError)
            : this(Comparer<T>.Default, throwOnError)
        {
        }
        public DynamicComparer(IComparer<T> comparer)
            : this(comparer, true)
        {
        }
        public DynamicComparer(IComparer<T> comparer, bool throwOnError)
        {
            this.comparer = comparer;
            this.throwOnError = throwOnError;
        }
        public static DynamicComparer<T> Default
        {
            get
            {
                return defaultComparer;
            }
        }
        public static DynamicComparer<T> DefaultNoThrow
        {
            get
            {
                return defaultNoThrowComparer;
            }
        }
        public int Compare(string x, string y)
        {
            T valueX;
            T valueY;
            bool convertedX = this.parser(x, out valueX);
            bool convertedY = this.parser(y, out valueY);
            if (this.throwOnError && !(convertedX && convertedY))
                throw new InvalidCastException();
            if (!(convertedX || convertedY))
                return 0;
            if (!convertedX)
                return 1;
            if (!convertedY)
                return -1;
            return this.comparer.Compare(valueX, valueY);
        }
        public bool Equals(string x, string y)
        {
            return Compare(x, y) == 0;
        }
        public int GetHashCode(string x)
        {
            T value;
            bool converted = this.parser(x, out value);
            if (this.throwOnError && !converted)
                throw new InvalidCastException();
            if (!converted)
                return 0;
            return value.GetHashCode();
        }
    }
    internal class DynamicComparerHelper
    {
        public delegate bool TryParseDelegate<T>(string text, out T value);
        private static readonly Dictionary<Type, Delegate> converters =
            new Dictionary<Type, Delegate>()
            {
                { typeof(bool), WrapDelegate<bool>(bool.TryParse) },
                { typeof(short), WrapDelegate<short>(short.TryParse) },
                { typeof(int), WrapDelegate<int>(int.TryParse) },
                { typeof(long), WrapDelegate<long>(long.TryParse) },
                { typeof(ushort), WrapDelegate<ushort>(ushort.TryParse) },
                { typeof(uint), WrapDelegate<uint>(uint.TryParse) },
                { typeof(ulong), WrapDelegate<ulong>(ulong.TryParse) },
                { typeof(float), WrapDelegate<float>(float.TryParse) },
                { typeof(double), WrapDelegate<double>(double.TryParse) },
                { typeof(DateTime), WrapDelegate<DateTime>(DateTime.TryParse) },
            };
        public static TryParseDelegate<T> GetParser<T>()
        {
            return (TryParseDelegate<T>)converters[typeof(T)];
        }
        private static TryParseDelegate<T> WrapDelegate<T>(TryParseDelegate<T> parser)
        {
            return new TryParseDelegate<T>(parser);
        }
    }
