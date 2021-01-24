    internal sealed class Configuration : DbMigrationsConfiguration<Linq_Issues.TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(Linq_Issues.TestContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.DeviceTests.AddOrUpdate(new DeviceTest
            {
                Env = new Linq_Issues.Environment
                {
                    Computer = "1",
                    OSVer = "Win",
                    User = "Test",
                    Version = "1",
                    TimeStamp = new DateTime(2018, 1, 22)
                }
            });
            context.DeviceTests.AddOrUpdate(new DeviceTest
            {
                Env = new Linq_Issues.Environment
                {
                    Computer = "2",
                    OSVer = "Linux",
                    User = "Ted",
                    Version = "1",
                    TimeStamp = new DateTime(2018, 1, 23)
                }
            }); context.DeviceTests.AddOrUpdate(new DeviceTest
            {
                Env = new Linq_Issues.Environment
                {
                    Computer = "1",
                    OSVer = "Win",
                    User = "Bill",
                    Version = "1",
                    TimeStamp = new DateTime(2018, 1, 24)
                }
            }); context.DeviceTests.AddOrUpdate(new DeviceTest
            {
                Env = new Linq_Issues.Environment
                {
                    Computer = "1",
                    OSVer = "Win",
                    User = "Ted",
                    Version = "1",
                    TimeStamp = new DateTime(2018, 1, 25)
                }
            }); context.DeviceTests.AddOrUpdate(new DeviceTest
            {
                Env = new Linq_Issues.Environment
                {
                    Computer = "2",
                    OSVer = "Linux",
                    User = "Bill",
                    Version = "1",
                    TimeStamp = new DateTime(2018, 1, 26)
                }
            }); context.DeviceTests.AddOrUpdate(new DeviceTest
            {
                Env = new Linq_Issues.Environment
                {
                    Computer = "2",
                    OSVer = "Linux",
                    User = "Bill",
                    Version = "1",
                    TimeStamp = new DateTime(2018, 1, 28)
                }
            }); context.DeviceTests.AddOrUpdate(new DeviceTest
            {
                Env = new Linq_Issues.Environment
                {
                    Computer = "2",
                    OSVer = "Linux",
                    User = "Jill",
                    Version = "1",
                    TimeStamp = new DateTime(2018, 1, 31)
                }
            });
        }
    }
