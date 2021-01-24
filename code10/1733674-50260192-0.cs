    public class DateConverter : IsoDateTimeConverter
    {
        public DateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
   
    public class A
    {
        [JsonConverter(typeof(DateConverter))]
        public DateTime date { get; set; }
    }
    public class B
    {
        public List<A> dates { get; set; }
    }
