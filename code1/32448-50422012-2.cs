    public class YourClass : FactoryObject
    {
        static YourClass()
        {
            Factory.RegisterType(new YourClass());
        }
        private YourClass() {}
    
        FactoryObject FactoryObject.Instantiate()
        {
            return new YourClass();
        }
    }
