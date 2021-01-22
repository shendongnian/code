    [Serializable]
    public class BaseClass : ParentClass
    {
    }
    [Serializable]
    [XmlInclude(typeof(BaseClass))]
    public class ParentClass
    {
    }
