    public class API_Methods
    {
    public rootObject RootObject { get; set; }
    public Boolean SubmitConsignment(out string JSONData)
    {
        string JSONData = JsonConvert.SerializeObject(NewRequestObject);
        return true;
    }
