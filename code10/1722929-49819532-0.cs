      var orderDate = Convert.ToDateTime("04/14/2018");
      var accurateDate = new DateTime(
        orderDate.Year, 
        orderDate.Month, 
        orderDate.Day, 
        DateTime.Now.Hour, 
        DateTime.Now.Minute, 
        DateTime.Now.Second);
