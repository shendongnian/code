        static Task<int> WithResult()
        {
            var tcs = new TaskCompletionSource<int>();
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                tcs.SetResult(2222);
            });
            return tcs.Task;
        }
        static Task WithNoResult()
        {
            var tcs = new TaskCompletionSource<int>();
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                tcs.SetResult(default(int)); 
            });
            return tcs.Task;
        }
        static async Task InitiateTasks()
        {
            var result = await WithResult();
			Console.WriteLine(result);
            await WithNoResult();
			Console.WriteLine("No result");
        }
