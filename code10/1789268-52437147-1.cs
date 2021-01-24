    static async Task Main()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://api.openweathermap.org");
        var response = await client.GetAsync($"/data/2.5/weather?q=London,UK&appid=c44d8aa0c5e588db11ac6191c0bc6a60&units=metric");
        // This line gives me error
        var stringResult = await response.Content.ReadAsStringAsync();  
    }
