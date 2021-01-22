    [JsonObject(MemberSerialization.OptIn)]
    public class Error : Exception, ISerializable
    {
    	[JsonProperty(PropertyName = "error")]
    	public string ErrorMessage { get; set; }
    
    	[JsonConstructor]
    	public Error() { }
    }
