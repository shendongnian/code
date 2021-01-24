    class Program
    {
        static async Task Main(string[] args)
        {
            var client=new HttpClient();
            var data = new StringContent("Metadata/Type=\"sas\"",Encoding.UTF8,"application/x-www-form-urlencoded");
            var response = await client.PostAsync("http://www.google.com/bcknd/republish", data);
            if(response.IsSuccessStatusCode)
            {
                var  responseContent = response.Content;
                var body=await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
            else 
            {
                Console.WriteLine($"Oops! {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
