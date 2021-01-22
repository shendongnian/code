    // 1. Step Create item1
    var item1 = new Record();
    item1.ID = 1;
    item1.UnknownInt = new UnknownInt(1, true);
   
    // 2. Setp Create item2
    var item2 = new Record();
    item2.ID = 2;
    item2.UnknownImt = new UnknownInt(1, false);
    if (item1.UnknownInt == item2.UnknownInt)
        Console.WriteLine("???");
    else
        Console.WriteLine("Profit!!!");
