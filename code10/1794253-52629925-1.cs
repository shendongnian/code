    public interface IMetadata
    {
        string Name {set; get;}
    }
    
    public class Metadata<T>:IMetadata
    {
        public string Name {set; get;}
    }
