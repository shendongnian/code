        StaticticsDelegate del = BowlerStatistics; // *
        RunsScoredEventArgs re = new RunsScoredEventArgs("Skeet", 55);
        del(DynamicDelegates.Main, re);
        del = BatsmanStatistics; // *
        BallThrownEventArgs be = new BallThrownEventArgs(90, 145);
        del(DynamicDelegates.Main,be);
        Console.ReadLine();
