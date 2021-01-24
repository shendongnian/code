        public class Temperature
        {
        	public Dictionary<DateTime, float> data { get; set; }
        	public Meta meta { get; set; }
        }
    And now you can cope with any `DateTime` being passed in, you would use it like this:
        var data = obj[0].data.Temperature.data;
        Console.WriteLine($"The temperature on {data.Key} was {data.Value}");
