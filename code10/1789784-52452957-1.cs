    public class OpenWeatherResponse 
    {
        public class MainClass
        {
            public float temp { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
        }
        public MainClass Main { get; set; } = new MainClass();
    }
