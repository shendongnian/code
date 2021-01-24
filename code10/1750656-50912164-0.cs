        static void Main(string[] args)
        {
            var app = new Program();
            var i = 0;
            var j = 0;
            var tasks = new List<Task>();
            while (j < 1000)
            {
                tasks.Add(app.CreateOpp(j));
                Console.WriteLine(i);
                if (i == 100)
                {
                    var done = Task.WhenAll(tasks);
                    done.Wait();
                    i = 0;
                    tasks = new List<Task>();
                }
                i++;
                j++;
            }
        }
            private async Task CreateOpp(int i)
        {
            var client = new RestClient("https...");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer Token");
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteTaskAsync(request);
            Console.WriteLine(i + " Status: " + response.StatusCode);
            Console.WriteLine();
        }
