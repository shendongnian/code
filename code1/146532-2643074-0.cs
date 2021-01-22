    public class MockRepository : IRepository<IModel>
    {
        public IModel Get(int id)
        {
            throw new NotImplementedException();
        }
    
        public void Update()
        {
            throw new NotImplementedException();
        }
    
        public int Add(IModel item)
        {
            throw new NotImplementedException();
        }
    }
