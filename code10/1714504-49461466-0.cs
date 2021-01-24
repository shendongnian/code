    public class JoinAndWrite
    {
        public JoinAndWrite()
        {
        }
        [Benchmark]
        public void Comma() => SharedAlgorithm(",");
        [Benchmark]
        public void At() => SharedAlgorithm("@");
        [Benchmark]
        public void Dollar() => SharedAlgorithm("$");
        private void SharedAlgorithm(string delimiter)
        {
            var filenameBase = ((int)delimiter[0]).ToString();
            List<string> lines = new List<string>();
            string example = string.Join(delimiter, new[] { "qwasdasdasde", "qwasdasdasde", "qwasdasdasde", "qwasdasdasde", "qwasdasdasde", "qwasdasdasde", "qwasdasdasde" });
            for (int i = 0; i < 30; i++)
            {
                lines.Add(example);
            }
            for (int i = 1; i <= 10; i++)
            {
                File.WriteAllLines($"{filenameBase}-_attempt-{i}.txt", lines);
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<JoinAndWrite>();
        }
    }
