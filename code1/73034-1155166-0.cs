    [StructLayout(LayoutKind.Explicit)] // used create a union of Long and Double
    public struct IEEE754
    {
        private const ulong SIGN_BITS     = 0x8000000000000000;
        private const ulong EXPONENT_BITS = 0x7FF0000000000000;
        private const ulong FRACTION_BITS = 0x000FFFFFFFFFFFFF;
    
        private const int SIGN_OFFSET     = 63;
        private const int EXPONENT_OFFSET = 52;
    
        // [FieldOffset] attribute is .NET's way of defining how to explicitly
        // layout the fields of a structure - we're using it to overlay the
        // double and long into a single bit-space ... effectively a C# 'union'
        [FieldOffset( 0 )] private double DoubleValue;
        [FieldOffset( 0 )] private ulong LongValue;
    
        public IEEE754(double val)
        {
            DoubleValue = val;
        }
        // properties that retrieve the various pieces of an IEEE754 double
        public long Fraction { get { return (long)(LongValue & FRACTION_BITS); } }
        public long Exponent { get { return (long)((LongValue & EXPONENT_BITS) >> EXPONENT_OFFSET); } }
        public long Sign     { get { return (long)((LongValue & SIGN_BITS) >> SIGN_OFFSET); } }
    
        public void Set( double val ) { DoubleValue = val; }
    }
    public static void TestFunction()
    {
        var array = Enumerable.Range( 1, 10000 ).ToArray();   // test array...
        // however you access your random generator would go here...
        var rand = new YourRandomNumberGenerator();
        // crack the double using the special union structure we created...
        var dul = new IEEE754( rand.GenRandomNumber() );
        // use the factional value modulo the array length as a random index...
        var randomValue = array[dul.Fraction % array.Length];
    }
