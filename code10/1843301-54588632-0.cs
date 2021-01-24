public class Error
{
  public class Details
  {
    public string Name {get;set}
    public string Id {get;set}
    public string Location {get;set}
  }
  public Dictionary<string, Details> Errors {get;set;}
}
