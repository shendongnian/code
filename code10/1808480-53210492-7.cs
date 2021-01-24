     public int GetTravelDaysWithinRange(DateTime rangeStart, DateTime rangeEnd)
     {
         if (rangeEnd < StartDate || rangeStart > EndDate)
         {
             return 0;
         }
         var startInRange = (rangeStart < StartDate) ? StartDate : rangeStart;
         var endInRange = (rangeEnd > EndDate) ? EndDate : rangeEnd;
         return (endInRange - startInRange).Days;
     }
