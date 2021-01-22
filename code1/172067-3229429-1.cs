    var now = DateTime.Now;
    var utcNow = DateTime.UtcNow;
    Console.WriteLine(now);                         // 12/07/2010 16:44:16
    Console.WriteLine(utcNow);                      // 12/07/2010 15:44:16
    Console.WriteLine(now.ToUniversalTime());       // 12/07/2010 15:44:16
    Console.WriteLine(utcNow.ToUniversalTime());    // 12/07/2010 15:44:16
            
    Console.WriteLine(now == utcNow);                         // False
    Console.WriteLine(now.ToUniversalTime() == utcNow);       // True
    Console.WriteLine(utcNow.ToUniversalTime() == utcNow);    // True
