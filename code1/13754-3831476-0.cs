    public class BaseClass
    {
        public BaseClass(params int[] parameters)
        {
            
        }   
    }
    
    public class ChildClass : BaseClass
    {
        public ChildClass(params int[] parameters)
            : base(parameters)
        {
    
        }
    }
