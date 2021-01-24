    class Program
    {
        public static async Task<int> GetResult(int timing)
        {
            return await Task<int>.Run(() =>
            {
                Thread.Sleep(timing * 1000);
                return timing;
            });
        }
        public static async Task<List<int>> GetAll()
        {
            List<int> tasks = new List<int>();
            tasks.Add(await GetResult(3));
            tasks.Add(await GetResult(2));
            tasks.Add(await GetResult(1));
            return tasks;
        }
        static void Main(string[] args)
        {
            var res = GetAll().Result;
        }
    }
