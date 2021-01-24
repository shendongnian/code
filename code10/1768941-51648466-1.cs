    class Program
    {
        public static Task<int> TransactionOperation1()
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            tasks.Add(tcs);
            return tcs.Task;
        }
        public static Task<int> TransactionOperation2()
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            tasks.Add(tcs);
            return tcs.Task;
        }
        public static async Task<int> ExecuteTransactionOnDB()
        {
            await Task.Delay(1000);
            return 5;
        }
        public static async Task TriggerTransaction()
        {
            int value = await ExecuteTransactionOnDB();
            foreach (var item in tasks)
            {
                item.SetResult(value);
            }
        }
        public static List<dynamic> tasks = new List<dynamic>();
        static async Task Main(string[] args)
        {
            Task<int> a = TransactionOperation1();
            Task<int> b = TransactionOperation2();
            Task input = Task.Run(async () => {
                while (Console.ReadKey().Key != ConsoleKey.A);
                await TriggerTransaction();
            });
            if (!File.Exists("C:\\temp\\data.txt"))
            {
                File.Create("C:\\temp\\data.txt").Close();
            }
            using (FileStream stream = new FileStream("C:\\temp\\data.txt", FileMode.Append, FileAccess.Write))
            {
                int sum = await a + await b; // now it works ok
                var bytes = Encoding.UTF8.GetBytes(sum.ToString());
                stream.Write(bytes);
            }
            Console.WriteLine(await a + await b);
        }
    }
