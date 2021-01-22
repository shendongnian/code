    public class SomeClass
    {
        private readonly IRepository1 repository;
        public SomeClass(IRepository1 repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            this.repository = repository;
        }
        // More members...
    }
