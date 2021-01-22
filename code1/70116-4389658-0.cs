    internal class YourPostInsertListener : IPostInsertEventListener
    {
        IKernel Kernel
        {
            get 
            { 
                return ServiceLocator.Current.GetInstance<IKernel>(); 
            }
        }
        IPersistentAuditor 
        {
           get
           {
                return Kernel.Get<IPersistentAuditor>();
           }
        }
        // ... Rest of class
    }
