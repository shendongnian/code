            string start = "2018-08-31";
            string end = "2018-08-31";
            DateTime startDate = Convert.ToDateTime(start + "T00:00:00");
            DateTime endDate = Convert.ToDateTime(end + "T23:59:59");
            Console.WriteLine(startDate);                   // 8/31/2018 12:00:00 (Local)
            Console.WriteLine(startDate.ToUniversalTime()); // 8/31/2018 5:00:00 (UTC)
            Console.WriteLine(endDate);                     // 8/31/2018 11:59:59 (Local)
            Console.WriteLine(endDate.ToUniversalTime());   // 9/1/2018 4:59:59 (UTC)
