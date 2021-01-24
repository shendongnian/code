    namespace asynctest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Do().GetAwaiter().GetResult();
            }
    
            public static async Task Do()
            {   
                for(int i=0;i<10;i++)
                {
                    
                  var task1 = Wait(5000);
                  var task2 = Wait(3000);   
                  int[] result = await Task.WhenAll(task1, task2);
                  Console.WriteLine("waited for a total of " + result.Sum() + " ms");          
                }
            }
    
            public static async Task<int> Wait(int i)
            {
                await Task.Delay(i);
                return i;
            }
        }
    }
