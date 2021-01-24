    public class API
    {
        DataAccessClass _dataAccess = new DataAccessClass();
    
        public List<Items> GetById(int id)
        {
            return _dataAccess.Get(id);
        }
    
        protected internal class DataAccessClass
        {
            protected internal List<Items> GetByInt(int id)
            { 
                using (var context = dbcontext)
                {
                    return context.GetItems();
                }
            }
    		protected internal List<Items> GetByLong(long id)
            { 
                using (var context = dbcontext)
                {
                    return context.GetItems();
                }
            }
        }
    }
