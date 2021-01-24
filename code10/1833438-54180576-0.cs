        static async Task<string> CallWebAPI(string location)
        {
            //string output;
            using (HttpClient client = new HttpClient())
            {
                //Set base URI for HTTP requests
                client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather");
                //Tells server to send data in JSON format
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string strLocation = location;
                string strKey = "427hdh9723797rg87";
                //Send request and await response from server
                HttpResponseMessage response = await client.GetAsync("?q=" + strLocation + "&APPID=" + strKey);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    CurrentWeather weather = response.Content.ReadAsAsync<CurrentWeather>().Result;
                    //Convert temperature from Kelvin to Fahrenheit
                    float temp = weather.main.temp * 1.8f - 459.67f;
                    string strTempFahrenheit = temp.ToString("n0");
                    //Display output
                    return "The temperature in " + weather.name + " is " + strTempFahrenheit + "°F. \n";
                }
                else
                {
                    return "Invalid city name. \n";
                    //Console.WriteLine(output);
                    Main();
                }
            }
        }
