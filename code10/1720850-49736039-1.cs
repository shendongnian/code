    public abstract class BaseFieldValue<ToutputType,TinputType> : IFieldValue
    {
        ...
    }
    public class Project
    {
        public string ProjectName { get; set; }
        public List<IFieldValue> ProjectFields {get;set;}
    }
