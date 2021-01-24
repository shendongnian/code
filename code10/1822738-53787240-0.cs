    public class MatterList
    {
        [DeserializeAs(Name = "data")]
        public List<Matter> matters { get; set; }
        public Meta meta { get; set; }
    }
