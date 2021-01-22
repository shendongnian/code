        int GetMonthNumber(string month)
        {
            return System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames
                .Select((m, i) => new { Month = m, Number = i + 1 })
                .First(m => m.Month.ToLower() == month.ToLower())
                .Number;
        }
