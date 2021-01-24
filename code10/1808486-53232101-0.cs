     var travel = new List<Travel>
     {
         new Travel("Egypt", new DateTime(2017, 8, 4), new DateTime(2017, 8, 24) ),
         new Travel("Spain", new DateTime(2017, 11, 1), new DateTime(2017, 12, 10) ),
         new Travel("Detroit", new DateTime(2017,9, 15), new DateTime(2017, 12, 20) ),
         new Travel("Boston", new DateTime(2017,10, 15), new DateTime(2017, 11, 20) ),
    
     };
     var rangeStart = new DateTime(2017, 11, 1);
     var rangeEnd = new DateTime(2017, 11, 27);
     var Trip= travel.Where(s => s != null && s.City == "Boston");
     var sumOfDays= Trip.Sum(t => GetTravelDaysWithinRange(t.Start,t.End,rangeStart, rangeEnd));
 
