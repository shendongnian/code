    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var summary = BenchmarkRunner.Run<BenchmarkDelegate>();            
            }
        }
    }
    
    using BenchmarkDotNet.Attributes;
    
    namespace Test
    {
        [MemoryDiagnoser]
        public class BenchmarkDelegate
        {
            public delegate int GetInteger();
    
    
            [Benchmark]
            public int WithDelegate() => RunDelegated(WithoutDelegate);
    
            public int RunDelegated(GetInteger del) => del();
    
            [Benchmark]
            public int WithoutDelegate() => 0;
        }
    }
