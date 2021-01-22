[Serializable]
[DataContract(Namespace = "")]
public class SomeClass
{
    [DataMember(Order = 0)]
    public string FirstName
    { 
        get; set;
    }
    [DataMember(Order = 1)]
    public string LastName
    { 
        get; set;
    }
    [DataMember(Order = 2)]
    private IDictionary<long, string> customValues;
    public IDictionary<long, string> CustomValues
    {
        get { return customValues; }
        set { customValues = value; }
    }
}
