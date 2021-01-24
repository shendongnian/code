	public class WeatherAPI
	{
		public WeatherData GetWeatherData()
		{
			var data = new WeatherData();
			data.Coordinates = new Coordinates
			{
				Longitude = ...,
			};
			data.Weather = new Weather
			{
				Summary = ...,
			};
			
			return data;
		}
	}
