    using BenchmarkDotNet.Running;
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
