    private static int TotalMonthDifference(DateTime dtThis, DateTime dtOther)
        {
            int intReturn = 0;
            bool sameMonth = false;
            if (dtOther.Date < dtThis.Date) //used for an error catch in program, returns -1
                intReturn--;
            int dayOfMonth = dtThis.Day; //captures the month of day for when it adds a month and doesn't have that many days
            int daysinMonth = 0; //used to caputre how many days are in the month
            while (dtOther.Date > dtThis.Date) //while Other date is still under the other
            {
                dtThis = dtThis.AddMonths(1); //as we loop, we just keep adding a month for testing
                daysinMonth = DateTime.DaysInMonth(dtThis.Year, dtThis.Month); //grabs the days in the current tested month
                if (dtThis.Day != dayOfMonth) //Example 30 Jan 2013 will go to 28 Feb when a month is added, so when it goes to march it will be 28th and not 30th
                {
                    if (daysinMonth < dayOfMonth) // uses day in month max if can't set back to day of month
                        dtThis.AddDays(daysinMonth - dtThis.Day);
                    else
                        dtThis.AddDays(dayOfMonth - dtThis.Day);
                }
                if (((dtOther.Year == dtThis.Year) && (dtOther.Month == dtThis.Month))) //If the loop puts it in the same month and year
                {
                    if (dtOther.Day >= dayOfMonth) //check to see if it is the same day or later to add one to month
                        intReturn++;
                    sameMonth = true; //sets this to cancel out of the normal counting of month
                }
                if ((!sameMonth)&&(dtOther.Date > dtThis.Date))//so as long as it didn't reach the same month (or if i started in the same month, one month ahead, add a month)
                    intReturn++;
            }
            return intReturn; //return month
        }
