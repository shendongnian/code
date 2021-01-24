    [DataContract(Namespace ="youNamespace")]
    public class MyGeocodeResponse
    {
    [DataMember(Name="status")]
    public string Status { get; set; }
    [DataMember(Name="result")]
    public Result[] Results { get; set; }
    [DataMember(Name="partial_match", IsRequired = false)]
    public bool PartialMatch { get; set; }
    }
