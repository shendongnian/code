    public class Program
    {
        public static void Main()
        {
            List<WeatherDay> weatherDays = new List<WeatherDay>();
            //add day of week and temp
            weatherDays.Add(new WeatherDay(1, 84, 65));
            weatherDays.Add(new WeatherDay(2, 86, 66));
            weatherDays.Add(new WeatherDay(3, 81, 71));
            weatherDays.Add(new WeatherDay(4, 82, 60));
            weatherDays.Add(new WeatherDay(5, 82, 64));
            weatherDays.Add(new WeatherDay(6, 83, 69));
            weatherDays.Add(new WeatherDay(7, 84, 70));
            weatherDays.ForEach(wetherDay => {
                Console.WriteLine("The range for Day {0} of the week was {1}", wetherDay.Day, wetherDay.Range);
            });
            Console.ReadLine();
        }
    }
    public class WeatherDay
    {
        public int Day { get; set; }
        public int HighTemp { get; set; }
        public int LowTemp { get; set; }
        public WeatherDay(int day, int highTemp, int lowTemp)
        {
            this.Day = day;
            this.HighTemp = highTemp;
            this.LowTemp = lowTemp;
        }
        public int Range { get { return HighTemp - LowTemp; } }
    }
