     public int GetTravelDaysWithinRange(DateTime rangeStart, DateTime rangeEnd)
     {
         //if everything is outside of the range to be considered, return 0
         if (rangeEnd < StartDate || rangeStart > EndDate)
         {
             return 0;
         }
         //Find the Max of StartDate and rangeStart 
         var startInRange = (rangeStart < StartDate) ? StartDate : rangeStart;
         //And the Min of EndDate and rangeEnd
         var endInRange = (rangeEnd > EndDate) ? EndDate : rangeEnd;
         //and get the number of days in-between (and then add 1 so Mon-Fri is 5 days, not 4)
         return (endInRange - startInRange).Days + 1;
     }
