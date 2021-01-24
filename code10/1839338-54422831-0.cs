csharp
foreach(dynamic item in result.packs)
{
  string productCodeScheme = item.pack.productCodeScheme.ToString();
}
However, i would strongly suggest that you to deserialize your JSON responses into defined objects instead of using `dynamic`. `dynamics` are both insecure and inefficient. You can do someting like example below,
csharp
public class PackDetails
{
    public string productCodeScheme { get; set; }
    public string productCode { get; set; }
    public string serialNumber { get; set; }
    public string batchId { get; set; }
    public string expiryDate { get; set; }
}
public class Result
{
    public string operationCode { get; set; }
    public string warning { get; set; }
    public string information { get; set; }
    public string state { get; set; }
}
public class Pack
{
    public PackDetails pack { get; set; }
    public Result result { get; set; }
}
public class ResponseObject
{
    public string operationCode { get; set; }
    public List<Pack> packs { get; set; }
}
then you can deserialize a `ResponseObject` like below and use it
csharp
var responseObject = JsonConvert.DeserializeObject<ResponseObject>();
foreach(PackDetails item in responseObject.packs)
{
  string productCodeScheme = item.pack.productCodeScheme;
}
