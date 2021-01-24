    using System.Globalization;
    public int getPreviousMonth(int month)
    {
        if (month > 1)
            return (month - 1);
        return (12);
    }
    DateTimeFormatInfo dtfi = new DateTimeFormatInfo(); //System.Globalization
    int CurrentMonth = DateTime.Now.Month;
    int PreviousMonth = getPreviousMonth(CurrentMonth);
    int PreviousPreviousMonth = getPreviousMonth(PreviousMonth);
    Debug.WriteLine(dtfi.GetMonthName(CurrentMonth).ToString()); //August
    Debug.WriteLine(dtfi.GetMonthName(PreviousMonth).ToString()); //July
    Debug.WriteLine(dtfi.GetMonthName(PreviousPreviousMonth).ToString()); //June
