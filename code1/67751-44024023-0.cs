       private async Task<List<IncomeStastistic>> GetWeeklyIncomeStatisticsData(DateTime startDate, DateTime endDate)
        {
            var dailyRecords = await GetDailyIncomeStatisticsData(startDate, endDate);
            var firstDayOfWeek = DateTimeFormatInfo.CurrentInfo == null
                ? DayOfWeek.Sunday
                : DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek;
            var incomeStastistics = new List<IncomeStastistic>();
            decimal weeklyAmount = 0;
            var weekStart = dailyRecords.First().Date;
            var isFirstWeek = weekStart.DayOfWeek == firstDayOfWeek;
            dailyRecords.ForEach(dailyRecord =>
            {
                if (dailyRecord.Date.DayOfWeek == firstDayOfWeek)
                {
                    if (!isFirstWeek)
                    {
                        incomeStastistics.Add(new IncomeStastistic(weekStart, weeklyAmount));
                    }
                    isFirstWeek = false;
                    weekStart = dailyRecord.Date;
                    weeklyAmount = 0;
                }
                weeklyAmount += dailyRecord.Amount;
            });
            incomeStastistics.Add(new IncomeStastistic(weekStart, weeklyAmount));
            return incomeStastistics;
        }
 
