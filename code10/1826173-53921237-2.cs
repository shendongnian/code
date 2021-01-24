             public async static Task Main(string[] args)
                {
    
    YourClassName classInstance = new YourClassName();
                    // Bind the event to something
                    classInstance .CompletedTaskEvent += (s, e) => Console.WriteLine("Completed work");
            
                    // Start the work
                    await classInstance.DoCleanup();
            
                    Console.ReadLine();
                }
            
        
        public class YourClassName
        {
                // Some event
                public event EventHandler CompletedTaskEvent;
            
            
                public async Task DoCleanup()
                {
                    await Task.Run(async () =>
                    {
                        await Task.Delay(2500);
            
                        // When the task completes invoke the event
                        // And pass the current class instance to the sender
                        // And you can add any kind of event argument you want
                        // however I recommend you make the event generic and then pass the argument type
                        CompletedTaskEvent?.Invoke(this, eventArguments);
                    });
                }
        }
                
