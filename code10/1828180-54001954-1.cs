    if (i.DoCalculateAllHistory) 
    {
        var quarterlyTask = CalcQuarterlyFigures(QuarterlyPrices, i.SeriesID);
        var weeklyTask = CalcWeeklyFigures(WeeklyPrices, i.SeriesID);
        var monthlyTask = CalcMonthlyFigures(MonthlyPrice, i.SeriesID);
        // Task.WhenAll accepts "params" array
        await Task.WhenAll(quarterlyTask, weeklyTask, monthlyTask);
        // You don't need to check for .Count
        // nothing will be added when empty list given to .AddRange  
        quartPerfFig.AddRange(await quarterlyTask);
        weeklyPerfFig.AddRange(await weeklyTask);
        monthlyPerfFig.AddRange(await monthlyTask);
    } 
    else 
    {
        var monthly = await CalcMonthlyFigures(MonthlyPrice, i.SeriesID);
        monthlyPerfFig.AddRange(monthly);
    }
