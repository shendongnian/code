    public class A
    {
        [JsonConverter(typeof(ArrayJsonConverter<B>))]
        public List<B> b { get; set; }
    }
