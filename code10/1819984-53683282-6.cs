    public interface IDataRepository
    {
      void Create(Data obj)
    }
    
    public class DataRepository : IDataRepository
    {
        private readonly DatabaseContext _context;
        public DataRepository (DatabaseContext context)
        {
            _context = context;
        }
       public void Create(Data data)
       {
          //eventually check for violations
          _context.Add(data);
          _context.SaveChanges();
       }
    }
