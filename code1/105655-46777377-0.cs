    public static class Extensions
    {
        public static HashSet<Type> NumericTypes = new HashSet<Type>()
        {
            typeof(byte), typeof(sbyte), typeof(ushort), typeof(uint), typeof(ulong), typeof(short), typeof(int), typeof(long), typeof(decimal), typeof(double), typeof(float)
        };
        public static bool IsNumeric1(this object o) => NumericTypes.Contains(o.GetType());
        public static bool IsNumeric2(this object o) => o is byte || o is sbyte || o is ushort || o is uint || o is ulong || o is short || o is int || o is long || o is decimal || o is double || o is float;
        public static bool IsNumeric3(this object o)
        {
            switch (o)
            {
                case Byte b:
                case SByte sb:
                case UInt16 u16:
                case UInt32 u32:
                case UInt64 u64:
                case Int16 i16:
                case Int32 i32:
                case Int64 i64:
                case Decimal m:
                case Double d:
                case Single f:
                    return true;
                default:
                    return false;
            }
        }
        public static bool IsNumeric4(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {           
            var count = 100000000;
            //warm up calls
            for (var i = 0; i < count; i++)
            {
                i.IsNumeric1();
            }
            for (var i = 0; i < count; i++)
            {
                i.IsNumeric2();
            }
            for (var i = 0; i < count; i++)
            {
                i.IsNumeric3();
            }
            for (var i = 0; i < count; i++)
            {
                i.IsNumeric4();
            }
            //Tests begin here
            var sw = new Stopwatch();
            sw.Restart();
            for (var i = 0; i < count; i++)
            {
                i.IsNumeric1();
            }
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            for (var i = 0; i < count; i++)
            {
                i.IsNumeric2();
            }
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            for (var i = 0; i < count; i++)
            {
                i.IsNumeric3();
            }
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            for (var i = 0; i < count; i++)
            {
                i.IsNumeric4();
            }
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);
        }
