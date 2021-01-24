    services.AddMvc()
        .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.DateFormatHandling =
                    DateFormatHandling.IsoDateFormat;
                opt.SerializerSettings.DateTimeZoneHandling =
                    DateTimeZoneHandling.Unspecified
               // Or maybe DateTimeZoneHandling.Utc - you should test!
            });
