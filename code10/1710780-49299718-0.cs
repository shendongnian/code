    public class SpanBenchmarks
    {
        private const int Iterations = 100_000;
        private byte[] _data;
        private LargeStruct _control;
        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new byte[1000];
            new Random().NextBytes(_data);
            _control = new LargeStruct(_data[0], _data[1], _data[2], _data[3], _data[4], _data[5]);
        }
        [Benchmark]
        public void PassSpanByValue()
        {
            for (int i = 0; i < Iterations; i++) AcceptSpanByValue(_data);
        }
        [Benchmark]
        public void PassSpanByRef()
        {
            for (int i = 0; i < Iterations; i++) AcceptSpanByRef(_data);
        }
        [Benchmark]
        public void PassLargeStructByValue()
        {
            for (int i = 0; i < Iterations; i++) AcceptLargeStructByValue(_control);
        }
        [Benchmark]
        public void PassLargeStructByRef()
        {
            for (int i = 0; i < Iterations; i++) AcceptLargeStructByRef(_control);
        }
        private int AcceptSpanByValue(ReadOnlySpan<byte> span) => span.Length;
        private int AcceptSpanByRef(in ReadOnlySpan<byte> span) => span.Length;
        private decimal AcceptLargeStructByValue(LargeStruct largeStruct) => largeStruct.A;
        private decimal AcceptLargeStructByRef(in LargeStruct largeStruct) => largeStruct.A;
        private readonly struct LargeStruct
        {
            public LargeStruct(decimal a, decimal b, decimal c, decimal d, decimal e, decimal f)
            {
                A = a;
                B = b;
                C = c;
                D = d;
                E = e;
                F = f;
            }
            public decimal A { get; }
            public decimal B { get; }
            public decimal C { get; }
            public decimal D { get; }
            public decimal E { get; }
            public decimal F { get; }
        }
    }
