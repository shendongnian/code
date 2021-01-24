    public class Content
    {
       [JsonProperty("requests")]
       public Request Value { get; set; }
    }
    public class Request
    {
       [JsonProperty("var_args")]
       public VarArgs[] Arguments { get; set; }
    }
    public class VarArgs
    {
       [JsonProperty("title")]
       public object Title { get; set; }
       [JsonProperty("owner")]
       public object Owner { get; set; }
    }
