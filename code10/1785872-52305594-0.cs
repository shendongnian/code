    public class BaseEntity
    {
        int val;
        protected string name;
        public string Name
        {
            get
            {
                return name; // Only get is exposed to prevent modifications
            }
        }
    }
    
    public class ClassA : BaseEntity
    {
       // Other fields or methods
    }
    
    public class ClassB : BaseEntity
    {
        // Other fields or methods
    }
