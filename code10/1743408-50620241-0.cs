    int? min = null;
    int? max = null;
    allFilteredCars
        .SelectMany(car => car.LeasingPlans
            .SelectMany(plan => plan.Durations))
                .Select(a =>
                {
                    if (min == null || a.MonthlyPrice < min.Value)
                    {
                        min = a.MonthlyPrice;
                    }
                    if (max == null || a.MonthlyPrice > max.Value)
                    {
                        max = a.MonthlyPrice;
                    }
                    return true;
                }).All(x => x);
