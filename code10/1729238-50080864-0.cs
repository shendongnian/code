    [DataContract]
    public class SomeClass
    {
        [DataMember]
        [JsonProperty("someDate")]
        [JsonConverter(typeof(ShortDateConverter))]       
        [System.ComponentModel.DataAnnotations.DataType(DataType.Date)]
        public DateTime SomeDate { get; set; }
    }
