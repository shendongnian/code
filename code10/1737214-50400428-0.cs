    public partial class MyDbContext : DbContext {
        public MyDbContext()
            : base(Properties.Settings.Default.MyDbConnString) {
        }
    }
