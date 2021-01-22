    public class MyClass
    {
        private readonly IBlogRepository repository;
        public MyClass(IBlogRepository repository)
        {
            if(repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            this.repository = repository;
        }
        // use this.repository in other members
    }
