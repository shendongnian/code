    public abstract class Field<T>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class Field<T> : Field
    {    
        public T Value { get; set; }
    
        /*
        ...
        */
    }
