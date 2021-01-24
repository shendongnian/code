public class Morning
{
    public string name { get; set; }
    public string id { get; set; }
    public string status { get; set; }
}
public class Afternoon
{
    public string name { get; set; }
    public string id { get; set; }
    public string status { get; set; }
}
public class RootObject
{
    public List<Morning> morning { get; set; }
    public List<Afternoon> afternoon { get; set; }
}
Generated using [json2csharp.com][1].
  [1]: http://json2csharp.com
After that, just deserialize and you're good to go.
