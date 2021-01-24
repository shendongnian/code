        static void Main(string[] args)
        {   
            for (int i = 0; i < 5000; i++)
            {
                PostData();
            }
        }
        static async void PostData()
        {
            HttpClient client = new HttpClient();
            await client.GetStringAsync("https://www.google.com.ph");
        }
         
