    static int TotelMonthDifference(this DateTime dtThis, DateTime dtOther)
    {
        int intReturn = 0;
        dtThis = dtThis.Date.AddDays(-(dtThis.Day-1));
        dtOther = dtOther.Date.AddDays(-(dtOther.Day-1));
        while (dtOther.Date > dtThis.Date)
        {
            intReturn++;     
            dtThis = dtThis.AddMonths(1);
        }
        return intReturn;
    }
