    public decimal getTBonus()
    {
        decimal tBonus = 0;
        if (TrainHours <= 0 && Hours <= 0)
        { tBonus = 0; }
        else if (TrainHours >= (Hours * .15m))
        { tBonus = getTPay() * .15m; }
        else if (TrainHours >= (Hours * .1m))
        { tBonus = getTPay() * .125m; }
        else if (TrainHours >= (Hours * .08m))
        { tBonus = getTPay() * .05m; }
        else
        { tBonus = getTPay() * .025m; }
        return tBonus;
    }
    public decimal getTPay()
    {
        decimal paid = 0;
        if (Hours <= 0)
        { paid = 0; }
        else if (Hours > 40)
        { paid = (HourlyRate * 40) + Overtime() + getTBonus(); }
        else
        { paid = (Hours * HourlyRate) + getTBonus(); }
        return paid;
    }
