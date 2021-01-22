    static DateTime ContractDue(DateTime start, int months)
    {
         if (start.Month == start.AddDays(1).Month)
         { // Same month, just add the months
                return start.AddMonths(months);
         }
         // Last day of month... add a day, add the months, then go back one day
         return start.AddDays(1).AddMonths(months).AddDays(-1);
    }
