    public class WeatherViewModel
    {
        public string Day { get; set; }
        public string WheatherPicturePath { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
    }
    public class BindedDataContext
    {
        public ObservableCollection<WeatherViewModel> WeeklyWeather { get; set; }
        public WeatherViewModel SelectedDailyWeather { get; set; }
        //...
    }
    
    
