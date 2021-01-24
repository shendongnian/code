        static async Task Main(string[] args)
        {       
            try
            {
              // enable 1 of these calls
                var task = DoSomethingAsync();
              //  var task = DoSomethingTask();
                Console.WriteLine("Still Ok");
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
        }
        private static async Task DoSomethingAsync()
        {
            throw new NotImplementedException();            
        }
        private static Task DoSomethingTask()
        {
            throw new NotImplementedException();
            return Task.CompletedTask;
        }
