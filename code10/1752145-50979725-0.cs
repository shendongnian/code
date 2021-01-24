    namespace StringReplace
    {
        using BenchmarkDotNet.Attributes;
        using BenchmarkDotNet.Running;
    
        public class Program
        {
            static void Main(string[] args)
            {
                BenchmarkRunner.Run<Program>();
            }
    
            private String str = "String to be tested. String to be tested. String to be tested.";
    
            [Benchmark]
            public string Test1()
            {
                var a = str;
                a = a.Replace("i", "in");
                a = a.Replace("to", "ott");
                a = a.Replace("St", "Tsr");
                a = a.Replace(".", "\n");
                a = a.Replace("be", "or be");
                a = a.Replace("al", "xd");
    
                return a;
            }
    
            [Benchmark]
            public string Test2()
            {
                var a = str;
                a = a.Replace("i", "in").Replace("to", "ott").Replace("St", "Tsr").Replace(".", "\n").Replace("be", "or be").Replace("al", "xd");
    
                return a;
            }
        }
    }
