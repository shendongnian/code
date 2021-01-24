    var min = Int32.MaxValue;
    var max = Int32.MinValue;
    foreach(var filteredCard in allFilteredCars)
    {
        foreach(var leasingPlan in filteredCard) 
        {
            foreach(var car in leasingPlan.Durations) 
            {
              if(car.MonthlyPrice < min)
                min = car.MonthlyPrice;
              if(car.MonthlyPrice > min)
                max = car.MonthlyPrice;
            }
         }
    }
