    public interface IBusinessObject { }
    class BusinessObject : IBusinessObject
    {
        public static IBusinessObject New() 
        {
            return new BusinessObject();
        }
        protected BusinessObject() 
        { ... }
    }
