    public class MD4DelegateVsReflection
    {
        private MD4 md4 = MD4.Create();
        private byte[] data;
        [Params(1000, 10000)]
        public int N;
        public void SetupData()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }
        [GlobalSetup(Target = nameof(Reflection))]
        public void ReflectionSetup()
        {
            MD4.SetReflectionUtils();
            SetupData();
        }
        [GlobalSetup(Target = nameof(Delegate))]
        public void DelegateSetup()
        {
            MD4.SetDelegateUtils();
            SetupData();
        }
        [Benchmark]
        public byte[] Reflection() => md4.ComputeHash(data);
        [Benchmark]
        public byte[] Delegate() => md4.ComputeHash(data);
    }
