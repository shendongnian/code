    public static double CalculateCharges(TimeSpan time) 
    {
        if (time < TimeSpan.Zero)
        {
            throw new ArgumentException("Parking time cannot be less than 0", nameof(time));
        }
        const double initialPrice = 2.0;
        const double maxPrice = 10.0;
        if (time <= TimeSpan.FromHours(3))
        {
            return initialPrice;
        }
        if (time >= TimeSpan.FromHours(19))
        {
            return maxPrice;
        }
        // ignore the first 3 hours
        int hours = time.Hours - 3;
        // if time is 1 hour and 5 minutes we should charge 2 hours
        // No need to check for seconds, I suppose :)
        if (time.Minutes > 0)
        {
            hours++;
        }
        double finalPrice = initialPrice + (hours * 0.5);
        return finalPrice;
    }
