        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fi");
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fi");
        var format = @"dd\/MM\/yyyy HH\:mm\:ss";
        var dateString = DateTime.Now.ToString(format);
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
        var parsedDate = DateTime.ParseExact(dateString, format, null);
  
