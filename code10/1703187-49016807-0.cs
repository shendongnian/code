        public class Model1
        {
           public IQueryable<People> People { get; set; }
           public IQueryable<Address> Addresses { get; set; }
           public Model1()
           {
               People = new List<People>().AsQueryable() ;
               Addresses = new List<Address>().AsQueryable();
           }
       }
