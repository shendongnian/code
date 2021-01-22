    public class BenchmarkNullableCheck
    {
        static int? x = (new Random()).Next();
        public static bool CheckObjectImpl(object o)
        {
            return o != null;
        }
        public static bool CheckNullableImpl<T>(T? o) where T: struct
        {
            return o.HasValue;
        }
        [Benchmark]
        public bool CheckObject()
        {
            return CheckObjectImpl(x);
        }
        [Benchmark]
        public bool CheckNullable()
        {
            return CheckNullableImpl(x);
        }
    }
