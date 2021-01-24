    public abstract class BaseModel
    {
        public string BaseProperty1 { get; set; }
        public string BaseProperty2 { get; set; }
    }
    public class ChildModel : BaseModel
    {
        public int IdOfSthInDb { get; set; }
    }
