    public class MyClass
    {
        [JsonConverter(typeof(MyDateTimeConverter))]
        public DateTime MyDate { get; set; }
    }
