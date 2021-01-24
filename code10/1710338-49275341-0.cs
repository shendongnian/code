    MyDB db;
    if (user.Type == 1)
    {
        db = new MyDb("nameOfConnectionString1");
    }
    else
    {
        db = new MyDb("nameOfConnectionString2");
    }
