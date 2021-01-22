        static decimal monthDifference(DateTime d1, DateTime d2)
        {
            if (d1 > d2)
            {
                DateTime hold = d1;
                d1 = d2;
                d2 = hold;
            }
            decimal monthsApart = Math.Abs((12 * (d1.Year - d2.Year)) + d2.Month - d1.Month - 1);
            
            decimal daysinStartingMonth = DateTime.DaysInMonth(d1.Year, d1.Month);
            monthsApart = monthsApart + (1-((d1.Day - 1) / daysinStartingMonth));
            //  Replace (d1.Day - 1) with d1.Day incase you DONT want to have both inclusive difference.
            
            decimal daysinEndingMonth = DateTime.DaysInMonth(d2.Year, d2.Month);
            monthsApart = monthsApart + (d2.Day / daysinEndingMonth);
            return monthsApart;
        } 
