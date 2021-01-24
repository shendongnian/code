      class Program
      {
          public static async Task Main(string[] args)
          {
             await Task.Run(async () =>
             {
                MyAsyncFunc();
             });
             Console.WriteLine("done");
             Console.ReadLine();
          }
        static async Task MyAsyncFunc()
         {
            await Task.Delay(3000);
         }
      }
