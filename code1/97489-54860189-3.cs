    using BenchmarkDotNet.Attributes;
    
    namespace Test
    {
        [MemoryDiagnoser]
        public class BenchmarkDelegate
        {
            public delegate int GetInteger();
            GetInteger _delegateInstance;
            public BenchmarkDelegate()
            {
                _delegateInstance = WithoutDelegate;
            }
            [Benchmark]
            public int WithInstance() => RunDelegated(_delegateInstance);
            [Benchmark]
            public int WithDelegate() => RunDelegated(WithoutDelegate);
            public int RunDelegated(GetInteger del) => del();
            [Benchmark]
            public int WithoutDelegate() => 0;
        }
    }
