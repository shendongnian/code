     {
         interface IHangfireJob
         {
             [Queue("secondary")]
             void Execute();
         }
     }
     
     class Program : IHangfireJob
     {
         static void SomeMainMethod()
         {
            BackgroundJob.Enqueue(() => Execute());
         }
         public void Execute()
         {
     		Console.WriteLine("Fire-and-forget!");
         }
     }
