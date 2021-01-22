    static double CalculateFine(int speed, int year)
    {
        const double COST_PER_5_OVER = 87.5;
        const int SPEED_LIMIT = 15;
        const double INITIAL_FEE = 75;
        // The discount is the 50 for each year, scaled so that year 1 is
        // -50, year 2 is 0, and so on.
        double discount = year * 50 - 100;
        // This calculation assumes that speed >= SPEED_LIMIT
        int feeMultiplier = (int)((speed - SPEED_LIMIT) / 5);
        double fine = feeMultiplier * COST_PER_5_OVER + INITIAL_FEE;
        return discount + fine;
    }
