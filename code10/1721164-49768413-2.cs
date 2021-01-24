     var connection = @"Server=(localdb)\mssqllocaldb;Database=FridgeServer.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
     services.AddDbContext<AppDbContext>(
                options => {
                    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    options.UseSqlServer(connection);
                    //var config = Configuration["Data:DefaultConnection:ConnectionString"];
                    //options.UseInMemoryDatabase("Grocery")
                }
            );
      services.AddSingleton<IHostedService,FinalTest>(s => new FinalTest(new AppDbContext(null, connection) ));
