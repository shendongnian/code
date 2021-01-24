    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AsyncTask().Wait();
            }
            catch (Exception e)
            {
				...
            }
        }
        static async Task AsyncTask()
        {
		    ...
            var httpClient = new HttpClient();     
            var response = await httpClient.PostAsync(queryString, content);
            ...
        }
    }
