    [Serializable]
    public class Car
    {
        [XmlElement]
        string Code {get;set;}
    
        [XmlElement]
        CarType Type {get;set;}
    }
