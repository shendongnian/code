    DateTime dt1 =
        new DateTime(630822816000000000, System.DateTimeKind.Unspecified);
    DateTime dt2 = DateTime.Parse("1/1/2000 12:00:00 AM");
    Console.WriteLine(dt1);           // displays "01/01/2000 00:00:00"
    Console.WriteLine(dt2);           // displays "01/01/2000 00:00:00"
    Console.WriteLine(dt1 == dt2);    // displays "True"
