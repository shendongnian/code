    public class GeneralRepository<T> where T : class
        {
            private MyContext Context = new MyContext();
            protected DbSet<T> Dbset { get; set; }
            public GeneralRepository()
            {
               Dbset = Context.Set<T>();
            }
        public T SelectByID(int? id)
        {
            var Record = Dbset.Find(id);
            return (Record);
        }
      public class StudentRepositoy :GeneralRepository<Student>
        {
  
        }
