    public void DoWork()
    {
        GlobalWeatherSoapClient client = new GlobalWeatherSoapClient();
        client.GetWeatherCompleted += new EventHandler<WeatherCompletedEventArgs>(client_GetWeatherCompleted);
        client.GetWeatherAsync("Berlin", "Germany");
    }
    
    void client_GetWeatherCompleted(object sender, WeatherCompletedEventArgs e)
    {
        Console.WriteLine("Get Weather Result: " + e.Result);
    }
