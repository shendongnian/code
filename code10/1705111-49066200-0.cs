    public class Environment
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string User { get; set; }
        public string Computer { get; set; }
        public string OSVer { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
    public class DeviceTest
    {
        public int? Id { get; set; }
        public virtual Environment Env {get; set;}
    }
    public class TestContext : DbContext
    {
        public TestContext() : base("name=Testing")
        {
        }
        public DbSet<Linq_Issues.Environment> Envs { get; set; }
        public DbSet<DeviceTest> DeviceTests { get; set; }
    }
