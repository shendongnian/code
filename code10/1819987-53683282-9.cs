    public interface IGearComponentRepository
    {
      void Create(GearComponent obj)
    }
    
    public class GearComponentRepository : IGearComponentRepository
    {
        private readonly DatabaseContext _context;
        public GearComponentRepository (DatabaseContext context)
        {
            _context = context;
        }
       public void Create(GearComponent data)
       {
          _context.Add(data);
          _context.SaveChanges();
       }
    }
