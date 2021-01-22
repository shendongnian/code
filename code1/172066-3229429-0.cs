    var now = DateTime.Now;
    var utcNow = DateTime.UtcNow;
    Console.WriteLine(now);                                // 12/07/2010 15:36:16
    Console.WriteLine(utcNow);                             // 12/07/2010 14:36:16
    Console.WriteLine(now.ToUniversalTime());              // 12/07/2010 14:36:16
            
    Console.WriteLine(now == utcNow);                      // False
    Console.WriteLine(now.ToUniversalTime() == utcNow);    // True
