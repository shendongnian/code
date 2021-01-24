        public static void Main(string[] args)
        {
            //use var host to build the host
            var host = CreateWebHostBuilder(args).Build();
            using (var db = new DatabaseContext())
            {
                db.GearComponents.Add(new GearComponent("Text", "Descr.", "08.12.2018"));
                db.SaveChanges();
            }
            // Run host after seeding
            host.Run();
        }
    
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
