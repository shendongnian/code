    using System;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = Task.Run(Loop);
            // Don't do this normally! It's just as a simple demo
            // in a console app...
            task1.Wait();
            Console.WriteLine("First task done");
            
            Task task2 = new Task(() => Broken());
            task2.Start();
            // Don't do this normally! It's just as a simple demo
            // in a console app...
            task2.Wait();
            Console.WriteLine("Second task done");
        }
        
        static async Task Loop()
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine(i);
            }
        }
    
        static async void Broken()
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine(i);
            }
        }
    }
