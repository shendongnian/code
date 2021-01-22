     DateTime dt0 = new DateTime(2009, 3, 10);
     DateTime dt1 = new DateTime(2009, 3, 26);
     for (; dt0.Date <= dt1.Date; dt0=dt0.AddDays(3))
     {
        //Console.WriteLine(dt0.Date.ToString("yyyy-MM-dd"));
        //take action
     }
