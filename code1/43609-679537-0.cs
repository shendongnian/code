    public static class AggregateUnchanged {
        public static string Run(string input) {
            return input
                .Reverse()
                .Select(x => x.ToString())
                .Aggregate((x, y) => x + "." + y);
        }
    }
    
    public static class WithStringBuilder {
        public static string Run(string input) {
            var builder = new StringBuilder();
            foreach (var cur in input.Reverse()) {
                builder.Append(cur);
                builder.Append('.');
            }
    
            if (builder.Length > 0) {
                builder.Length = builder.Length - 1;
            }
    
            return builder.ToString();
        }
    }
    
    class Program {
        public static void RunAndPrint(string name, List<string> inputs, Func<string, string> worker) {
    
            // Test case. JIT the code and verify it actually works 
            var test = worker("123456");
            if (test != "6.5.4.3.2.1") {
                throw new InvalidOperationException("Bad algorithm");
            }
    
            var watch = new Stopwatch();
            watch.Start();
            foreach (var cur in inputs) {
                var result = worker(cur);
            }
            watch.Stop();
            Console.WriteLine("{0} ({2} elements): {1}", name, watch.Elapsed, inputs.Count);
        }
    
        public static string NextInput(Random r) {
            var len = r.Next(1, 1000);
            var builder = new StringBuilder();
            for (int i = 0; i < len; i++) {
                builder.Append(r.Next(0, 9));
            }
            return builder.ToString();
        }
    
        public static void RunAll(List<string> input) {
            RunAndPrint("Normal Aggregate", input, AggregateUnchanged.Run);
            RunAndPrint("WithStringBuilder", input, WithStringBuilder.Run);
        }
    
        static void Main(string[] args) {
            var random = new Random((int)DateTime.Now.Ticks);
            RunAll(Enumerable.Range(0, 100).Select(_ => NextInput(random)).ToList());
            RunAll(Enumerable.Range(0, 1000).Select(_ => NextInput(random)).ToList());
            RunAll(Enumerable.Range(0, 10000).Select(_ => NextInput(random)).ToList());
        }
    }
