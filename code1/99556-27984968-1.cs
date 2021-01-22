    /// <summary>
    /// Calculate the number of business days between two dates, considering:
    ///  - Days of the week that are not considered business days.
    ///  - Holidays between these two dates.
    /// </summary>
    /// <param name="fDay">First day of the desired 'span'.</param>
    /// <param name="lDay">Last day of the desired 'span'.</param>
    /// <param name="BusinessDaysOfWeek">Days of the week that are considered to be business days, if NULL considers monday, tuesday, wednesday, thursday and friday as business days of the week.</param>
    /// <param name="Holidays">Holidays, if NULL, considers no holiday.</param>
    /// <returns>Number of business days during the 'span'</returns>
    public static int BusinessDaysUntil(this DateTime fDay, DateTime lDay, DayOfWeek[] BusinessDaysOfWeek = null, DateTime[] Holidays = null)
    {
        if (BusinessDaysOfWeek == null)
            BusinessDaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        if (Holidays == null)
            Holidays = new DateTime[] { };
        fDay = fDay.Date;
        lDay = lDay.Date;
        if (fDay > lDay)
            throw new ArgumentException("Incorrect last day " + lDay);
        int bDays = (lDay - fDay).Days + 1;
        int fullWeekCount = bDays / 7;
        int fullWeekCountMult = 7 - WeekDays.Length;
        //  Find out if there are weekends during the time exceedng the full weeks
        if (bDays > (fullWeekCount * 7))
        {
            int fDayOfWeek = (int)fDay.DayOfWeek;
            int lDayOfWeek = (int)lDay.DayOfWeek;
            if (fDayOfWeek > lDayOfWeek)
                lDayOfWeek += 7;
            // If they are the same, we already covered it right before the Holiday subtraction
            if (lDayOfWeek != fDayOfWeek)
            {
                //  Here we need to see if any of the days between are considered business days
                for (int i = fDayOfWeek; i <= lDayOfWeek; i++)
                    if (!WeekDays.Contains((DayOfWeek)(i > 6 ? i - 7 : i)))
                        bDays -= 1;
            }
        }
        //  Subtract the days that are not in WeekDays[] during the full weeks in the interval
        bDays -= (fullWeekCount * fullWeekCountMult);
        //  Subtract the number of bank holidays during the time interval
        bDays = bDays - Holidays.Select(x => x.Date).Count(x => fDay <= x && x <= lDay);
        return bDays;
    }
