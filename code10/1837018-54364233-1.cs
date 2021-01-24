[Serializable]
public class Root
{
    [Key]
    public int Id { get; set; }
    public string stat { get; set; } // changed to a string
    public List<Result> results { get; set; }
}
[Serializable]
public class Result
{
    [Key]
    public int Id { get; set; }
    public List<String> _dataSets { get; set; }
    public List<string> dataSets // the JSON array will deserialize into this property
    {
        get { return _dataSets; }
        set { _dataSets = value; }
    }
    [Required]
    public string DatasetsAsString
    {
        get { return String.Join(",", _dataSets); }
        set { _dataSets = value.Split(',').ToList(); }
    }
    public string head{ get; set; }
    public virtual root { get; set; }
}
Edit: stat property has to be a string too.
