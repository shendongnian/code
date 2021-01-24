    public abstract class Metadata
    {
        public string Name {set; get;}
    }
    
    public class Metadata<T>:Metadata
    {
        //public string Name {set; get;}
    }
