    public static void Main(string[] args)
        {
            var listT = new List<string>()
            {
                "24006025062"
            };
            var task = list
                .Select(x => Task.Factory.StartNew(() => TesteTask(x)))
                .ToArray();
            Task.WaitAll(task, TimeSpan.FromSeconds(120));
            List<string> results = new List<string>();
            foreach (var result in task)
            {
                results.Add(result.Result);
            }
        }
