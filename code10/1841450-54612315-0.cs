public class QueryParameters
{
    public string manatoryParam1 {get; set;}
    public string manatoryParam2 {get; set;}
    public string optionalParamName1 {get; set;}
    public int optionalParamName2 {get; set;}
}
And then your controller will look like this:
[HttpGet]
public IActionResult Get(QueryParameters query)
Note: You should be returning IActionResult too - it helps with unit tests ;-)
