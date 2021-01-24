    public class Emp
    {
        [JsonConverter(typeof(MyCustomIntConverter))
        public int Id { get; set; }
        public long Volume { get; set; }
    }
    
    public class MyCustomIntConverter : JsonConverter<int>
    {
        //implement here
    }
