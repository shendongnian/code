    var FixedTime10PM = new DateTime(1, 1, 1, 22, 0, 0);
    var FixedTime02AM = new DateTime(1, 1, 1, 2, 0, 0);
    
    var dbTime = new DateTime(2018, 6, 20, 5, 0, 0);
    
    var dt1 = GetClosingTime(FixedTime10PM, dbTime);
    var dt2 = GetClosingTime(FixedTime02AM, dbTime);
    
    Console.WriteLine(dt1.ToLongDateString() + " " + dt1.ToLongTimeString());
    Console.WriteLine(dt2.ToLongDateString() + " " + dt2.ToLongTimeString());
