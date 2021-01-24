        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Continuing iteration " + i);
                    PostData(client);
                }
                Console.ReadKey();
            }
            
        }
        static async void PostData(HttpClient client)
        { 
            await client.GetStringAsync("https://www.google.com.ph");
            Console.WriteLine("Async call done");
        }
         
