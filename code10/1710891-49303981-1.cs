    public class MyDataContext : DataContext, IMyDataContext
    {
        public MyDataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
