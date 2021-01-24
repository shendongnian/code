    public class ChildManager : ParentManager<ChildPropertyType>
    {
    }
    
    public class ParentManager<T> where T: ParentPropertyType 
    {
        public T PropertyType { get; set; }   
    }
