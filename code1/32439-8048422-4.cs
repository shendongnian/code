    public interface IBusinessFactory { }
    class BusinessFactory : IBusinessFactory
    {
        public static IBusinessFactory New() 
        {
            return new BusinessFactory();
        }
        protected BusinessFactory() 
        { ... }
    }
