    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    [DatanContract]
    public class ADesired
    {
        [JsonIgnore]
        public B Inner { get; set; }
    
        [JsonIgnore]
        public string InnerJson { get; set; }
    
        [DataMember]
        [JsonProperty(nameof(Inner))
        public JObject JInner
        {
            get => JObject.FromObject(Inner);
            set { Inner = value.ToObject<B>(); InnerJson = value.ToString(); }
        }
    }
