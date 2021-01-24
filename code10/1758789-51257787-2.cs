    Random r = new Random(0);
    var byteSmall = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x03, 0x05, 0x07, 0x23 };
    var byteLarge = new byte[10000];
    for (int i = 0; i < byteLarge.Length; i++) byteLarge[i] = (byte)r.Next(255);
    int countSmall = 2_000_000;
    int countLarge = 1_000;
    Stopwatch swUnsafeSmall = Stopwatch.StartNew();
    for (int i = 0; i < countSmall; i++) GetIntsUnsafe(byteSmall);
    swUnsafeSmall.Stop();
    
    Console.WriteLine("Unsafe Small: " + swUnsafeSmall.ElapsedMilliseconds);
    Stopwatch swUnsafeLarge = Stopwatch.StartNew();
    for (int i = 0; i < countLarge; i++) GetIntsUnsafe(byteLarge);
    swUnsafeLarge.Stop();
    
    Console.WriteLine("Unsafe Large: " + swUnsafeLarge.ElapsedMilliseconds);
    Stopwatch swJohnSmall = Stopwatch.StartNew();
    for(int i = 0; i < countSmall;i++)
        GetIntsJohn(byteSmall);
    swJohnSmall.Stop();
    
    Console.WriteLine("John Small: " + swJohnSmall.ElapsedMilliseconds);
    Stopwatch swJohnLarge = Stopwatch.StartNew();
    for(int i = 0; i < countLarge;i++)
        GetIntsJohn(byteLarge);
    swJohnLarge.Stop();
    Console.WriteLine("John Large: " + swJohnLarge.ElapsedMilliseconds);
    Stopwatch swGeneralSmall = Stopwatch.StartNew();
    for(int i = 0; i < countSmall;i++)
        GetIntsGeneral(byteSmall);
    swGeneralSmall.Stop();
    
    Console.WriteLine("General Small: " + swGeneralSmall.ElapsedMilliseconds);
    Stopwatch swGeneralLarge = Stopwatch.StartNew();
    for(int i = 0; i < countLarge;i++)
        GetIntsGeneral(byteLarge);
    swGeneralLarge.Stop();
    Console.WriteLine("General Large: " + swGeneralLarge.ElapsedMilliseconds);
    Console.ReadLine();
