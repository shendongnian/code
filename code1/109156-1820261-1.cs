        int ndays = Weekdays(new DateTime(2009, 11, 30), new DateTime(2009, 12, 4));
        System.Console.WriteLine(ndays);
        // leap year test
        ndays = Weekdays(new DateTime(2000, 2,27), new DateTime(2000, 3, 5));
        System.Console.WriteLine(ndays);
        // non leap year test
        ndays = Weekdays(new DateTime(2007, 2, 25), new DateTime(2007, 3, 4));
        System.Console.WriteLine(ndays);
