    public abstract class CustomerServiceBase : ICustomerService
    {
        public abstract void DoOtherStuff();
        //You could mark this as virtual if you want the option to override functionality
        public string GetName()
        {
            return "John Doe";
        }
    }
