    public double CountAverage(Func<Athlete, double> func)
    {
        double Average = 0;
        double Amount = 0;
        foreach (Athlete athlete in this.Athletes)
        {
            Amount += func(athlete);
        }
        return Amount / this.Athletes.Count;
    }
