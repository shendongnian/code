    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var client1 = new Client<CurrentWeatherDTO>(null);
    		Console.WriteLine("Client CurrentWeather type: " + client1.Type);
    		
    		var client2 = new Client<FiveDayForecastDTO>(null);
    		Console.WriteLine("Client FiveDay type: " + client2.Type);
    	}
    	
    	public class Client<T> where T : IWeather, new()
        {
    		public string Type { get; set; }
    
            public Client(string apiKey)
            {
    			var dto = (IWeather)new T();
                this.Type = dto.GetAPIType();
            }
    	}
    	
    	public static class APIType
        {
            public static string CurrentWeather = "weather";
            public static string FiveDayForecast = "forecast";
        }
    	
    	public interface IWeather
        {
            string GetAPIType();
        }
    	
    	class CurrentWeatherDTO : IWeather
        {
            public string GetAPIType()
            {
                return APIType.CurrentWeather;
            }
        }
    	
    	class FiveDayForecastDTO : IWeather
        {
            public string GetAPIType()
            {
                return APIType.FiveDayForecast;
            }
        }
    }
