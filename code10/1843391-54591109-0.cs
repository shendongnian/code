 c#
public class Product
{
    [JsonProperty("ProductCode")]
    public string ProductCode { get; set; }
    [JsonProperty("ProductInfo")]
    public string ProductInfo { get; set; }
}
Without these, JSON.Net uses conventions and configuration - and the usual JSON convention *is* to use camel-case, hence that is the default. You *can* also probably change the default configuration, but I would advise against that unless you understand the scope of the impact.
