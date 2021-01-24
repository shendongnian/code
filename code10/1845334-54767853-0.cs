    public class DataContext : DbContext, IDataContext
    {
        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
              Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
              //NOTE: Instead of Debug.WriteLine, you can stroe it in DB.
        }
    .....
    .....
    .....
    }
