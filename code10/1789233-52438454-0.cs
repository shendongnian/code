    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
    
            static async Task Main()
            {
    
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync($"/data/2.5/weather?q=London,UK&appid=c44d8aa0c5e588db11ac6191c0bc6a60");
    
                // This line gives me error
                var stringResult = await response.Content.ReadAsStringAsync();
    
                var obj = JsonConvert.DeserializeObject<dynamic>(stringResult);
                var tmpDegreesF = Math.Round(((float)obj.main.temp * 9 / 5 - 459.67),2) ;
                Console.WriteLine($"Current temperature is {tmpDegreesF}°F");
                Console.ReadKey();
            }
          
         }
    }
