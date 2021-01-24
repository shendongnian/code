    services.AddMvc()
        .AddJsonOptions(options =>
            {
                options.SerializerSettings.Culture = new CultureInfo("tr-TR");
                // next line probably not needed
                // options.SerializerSettings.DateFormatString = "dd.MM.yyyy"; 
            });
