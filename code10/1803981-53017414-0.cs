    private static void Main(string[] args)
    {
       var t1 = Task.Run(
          () =>
             {
                Console.WriteLine($"{DateTime.Now.TimeOfDay} here 1");
                var val = Test.Value;
                Console.WriteLine($"{DateTime.Now.TimeOfDay} here 1 complete");
                return val;
             });
       var t2 = Task.Run(
          () =>
             {
                Console.WriteLine($"{DateTime.Now.TimeOfDay} here 2");
                var val = Test.Value;
                Console.WriteLine($"{DateTime.Now.TimeOfDay} here 2 complete");
                return val;
             });
       Task.WaitAll(t2, t2);
    }
    
    public static class Test
    {
       static Test()
       {
          Thread.Sleep(2000);
          Value = 1;
       }
    
       public static int Value { get; }
    }
