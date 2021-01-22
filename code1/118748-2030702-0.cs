    public class MyRepository : IMyRepository
    {
        private readonly DataContext dataContext;
        public MyRepository(DataContext dataContext)
        {
            if(dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }
            this.dataContext = dataContext;
        }
        // implement MyRepository using this.dataContext;
    }
