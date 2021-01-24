        static HelperClass()
        {
            // In this case all classes are present in the current assembly
            var items = Assembly.GetExecutingAssembly()
                                .GetTypes().Where(x =>
                                                  typeof(BaseViewModel)
                                                  .IsAssignableFrom(x))
                                .ToList();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                items.ForEach(x =>
                {
                    // Here use some naming convention or attribute to find out the Source and Destination Type
                    //Or use a dictionary which gives you source and destination type
                    cfg.CreateMap(x, x);
                });
            });
        }
