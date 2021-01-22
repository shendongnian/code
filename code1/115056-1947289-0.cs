    public void LastDayOfLastQuarter(DateTime date)
    {
        int result = (int)(date.Month/3)
        
        switch (result)
        {
            // January - March
            case 0:
                return new DateTime(date.Year - 1, 12, 31)
            // April - June
            case 1:
                return new DateTime(date.Year, 3, 31)
            // July - September
            case 2:
                return new DateTime(date.Year, 6, 30)
            // October - December
            case 3:
                return new DateTime(date.Year, 9, 30)
        }
    }
