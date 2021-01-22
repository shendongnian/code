    public class Part : inheritence...
    {
        public static IPartRepository Repository
        {
            get { return IoCContainer.GetInstance<IRepository<Part>>(); }
        }
        // ... more part-y stuff
    }
