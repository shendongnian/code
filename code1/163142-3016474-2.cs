    static int IfYouAintCheatinYouAintTryin()
    {
        List<Tuple<double, int>> iAlwaysWin = new List<Tuple<double, int>>();
        iAlwaysWin.Add(new Tuple<double, int>(0.02, 1));
        iAlwaysWin.Add(new Tuple<double, int>(0.04, 2));
        iAlwaysWin.Add(new Tuple<double, int>(0.06, 3));
        iAlwaysWin.Add(new Tuple<double, int>(0.08, 4));
        iAlwaysWin.Add(new Tuple<double, int>(0.10, 5));
        iAlwaysWin.Add(new Tuple<double, int>(1.00, 6));
        double realRoll = random.NextDouble(); // same random object as before
        foreach (var cheater in iAlwaysWin)
        {
            if (cheater.Item1 > realRoll)
                return cheater.Item2;
        }
        return 6;
    }
