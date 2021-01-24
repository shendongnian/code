    public class ToUInt64Benchmark
    {
        public BindingFlags FlagsValue = BindingFlags.Public | BindingFlags.Instance;
        public IConvertible FlagsValueAsConvertible;
        public ToUInt64Benchmark() => FlagsValueAsConvertible = FlagsValue;
        [Benchmark(Baseline = true)]
        public ulong EnumToUInt64() => FlagsValueAsConvertible.ToUInt64(null);
        [Benchmark]
        public ulong UnsafeEnumToUInt64() => ConvertUnsafe(FlagsValue);
        private static unsafe ulong ConvertUnsafe<T>(T enumValue) where T : struct, Enum
        {
            var pointer = (ulong*)Unsafe.AsPointer(ref enumValue);
            return *pointer;
        }
    }
