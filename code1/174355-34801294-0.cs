    public decimal getMonthDiff(DateTime date1, DateTime date2) {
        // Make parameters agnostic
        var earlyDate = (date1 < date2 ? date1 : date2);
        var laterDate = (date1 > date2 ? date1 : date2);
        // Calculate the change in full months
        decimal months = ((laterDate.Year - earlyDate.Year) * 12) + (laterDate.Month - earlyDate.Month) - 1;
        // Add partial months based on the later date
        if (earlyDate.Day <= laterDate.Day) {
            decimal laterMonthDays = DateTime.DaysInMonth(laterDate.Year, laterDate.Month);
            decimal laterPartialMonth = ((laterDate.Day - earlyDate.Day) / laterMonthDays);
            months += laterPartialMonth + 1;
        } else {
            var laterLastMonth = laterDate.AddMonths(-1);
            decimal laterLastMonthDays = DateTime.DaysInMonth(laterLastMonth.Year, laterLastMonth.Month);
            decimal laterPartialMonth = ((laterLastMonthDays - earlyDate.Day + laterDate.Day) / laterLastMonthDays);
            months += laterPartialMonth;
        }
        return months;
    }
