    services.AddDbContextPool<MvcMovieContext>(
                options => options.UseMySql("Server=localhost;Database=ef;User=root;Password=123456;", 
                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                    }
            ));
