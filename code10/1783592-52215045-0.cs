    using Newtonsoft.Json;
    public class User
    {
       //...
       [JsonIgnore]
       public DateTime CreatedAt  { get; set; }
       //...
    }
