     static void Main(string[] args)
            {
    
                Task.Delay(5000).GetAwaiter()
                .OnCompleted(() => Console.WriteLine("This will be done after"));
                
                Console.WriteLine("This will be done first");
                Console.ReadLine();
            }
        
