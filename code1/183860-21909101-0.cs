    modelBuilder.Properties()
        .Where(x => x.GetCustomAttributes(false).OfType<DecimalPrecisionAttribute>().Any())
        .Configure(c => {
            var attr = (DecimalPrecisionAttribute)c.ClrPropertyInfo.GetCustomAttributes(typeof (DecimalPrecisionAttribute), true).FirstOrDefault();
            c.HasPrecision(attr.Precision, attr.Scale);
        });
