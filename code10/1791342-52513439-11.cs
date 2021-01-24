     DateTime d1 = new DateTime(3, 10, 1); // 1 Oct 3 AD
     DateTime d2 = new DateTime(2, 8, 1);  // 1 Aug 2 AD
     DateTime result = d1
       .AddYears(d2.Year)
       .AddMonths(d2.Month);               // 1 Jun 6 AD
     // 6.6
     Console.Write($"{result.Year}.{result.Month}"); 
