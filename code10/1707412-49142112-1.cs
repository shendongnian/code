this.sortedDays = sortedDays;
	namespace WeatherForecast
	{
		/// <summary>
		/// An empty page that can be used on its own or navigated to within a Frame.
		/// </summary>
		public sealed partial class WeatherPage : Page
		{
			Forecast myForecast;
			public WeatherPage()
			{
				this.InitializeComponent();
		
				myForecast = new Forecast();
				// Task task =myForecast.GetWeather("id=2964179");
		        // POINT C
				myForecast.GetWeather("id=2964179").GetAwaiter().GetResult();
                //POINT D
				Debug.WriteLine("DEBUG IN WEATHERPAGE: " + myForecast.sortedDays[1][1].desc);
			}
		}
	}
	namespace WeatherForecast
	{
		class Forecast
		{
			public List<List<WeatherController>> sortedDays { get; set; }
			public RootObject result { get; set; }
		
			public Forecast()
			{
		
			}
			
			public async Task GetWeather(string cCode)
			{
				// DEBUG
				Debug.WriteLine("DEBUG: Started getWeather");
				string cityCode = cCode;
				string apiKey = "myapikey";
				// string cityCode = "id=2964179";
				string url = "myurl" + cityCode + apiKey;
		
		
				var uri = new Uri(url);
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage response = await client.GetAsync(uri))
					{
						using (IHttpContent content = response.Content)
						{
							var json = await content.ReadAsStringAsync();
		
							result = JsonConvert.DeserializeObject<RootObject>(json);
							//  SortWeather();
		
							// create a list of weatherController lists to hold each day
							// made public for global access
                            // POINT A
							List<List<WeatherController>> sortedDays = new List<List<WeatherController>>(); 
                             
                            // POINT B
							//    sortedDays = new List<List<WeatherController>>();
		
							//create a list of weatherController objects to hold each hourly interval
							List<WeatherController> sortedHours = new List<WeatherController>();
		
							// a base time
							DateTime prevDate = Convert.ToDateTime("2000-01-01");
							int counter = 0;
		
							// iterate through result list  
							for (int i = 0; i < result.list.Count(); i++)
							{
								// if the date is greater than the previous date add the sortedHours to sortedDays
								if (Convert.ToDateTime(result.list[counter].dt_txt).Date > prevDate.Date && counter != 0)
								{
									sortedDays.Add(sortedHours);
									sortedHours = new List<WeatherController>();
								}
								WeatherController wController = new WeatherController
								{
									dtime = result.list[counter].dt_txt,
									dayOfWeek = (Convert.ToDateTime(result.list[counter].dt_txt).DayOfWeek).ToString(),
									temp = result.list[counter].main.temp,
									humidity = result.list[counter].main.humidity,
									desc = result.list[counter].weather[0].description,
									windSpeed = result.list[counter].wind.speed
								};
								sortedHours.Add(wController);
		
								prevDate = Convert.ToDateTime(result.list[counter].dt_txt);
								counter++;
		
							}
							// add any left over sortedHours to sortedDays
							if (sortedHours != null)
							{
								sortedDays.Add(sortedHours);
							}
		
							Debug.WriteLine("DEBUG: Finished getWeather");
		
						}
					}
				}
			}
		}
	}
