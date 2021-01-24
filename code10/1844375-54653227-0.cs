    // calcuate carryover points by ISO 8601 : 1998 section 5.5.3.2.1 Alternate format
    // algorithm not to exceed 12 months, 30 day
    // note with this algorithm year has 360 days.
    private static void CarryOver(int inDays, out int years, out int months, out int days)
    {
        years = inDays / 360;
        int yearDays = years * 360;
        months = Math.Max(0, inDays - yearDays) / 30;
        int monthDays = months * 30;
        days = Math.Max(0, inDays - (yearDays + monthDays));
        days = inDays % 30;
    }        
    
    public static string ToSoapString(this TimeSpan timeSpan)
    {
        StringBuilder sb = new StringBuilder(20)
        {
            Length = 0
        };
        if (TimeSpan.Compare(timeSpan, TimeSpan.Zero) < 1)
        {
            sb.Append('-');
        }
    
        CarryOver(Math.Abs(timeSpan.Days), out int years, out int months, out int days);
    
        sb.Append('P');
        sb.Append(years);
        sb.Append('Y');
        sb.Append(months);
        sb.Append('M');
        sb.Append(days);
        sb.Append("DT");
        sb.Append(Math.Abs(timeSpan.Hours));
        sb.Append('H');
        sb.Append(Math.Abs(timeSpan.Minutes));
        sb.Append('M');
        sb.Append(Math.Abs(timeSpan.Seconds));
        long timea = Math.Abs(timeSpan.Ticks % TimeSpan.TicksPerDay);
        int t1 = (int)(timea % TimeSpan.TicksPerSecond);
        if (t1 != 0)
        {
            string t2 = t1.ToString("D7");
            sb.Append('.');
            sb.Append(t2);
        }
        sb.Append('S');
        return sb.ToString();
    }
