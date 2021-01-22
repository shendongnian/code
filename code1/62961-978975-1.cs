        bool IsEndOfMonth(DateTime date) {
            return date.AddDays(1).Day == 1;
        }
        DateTime AddMonthSpecial(DateTime date) {
            if (IsEndOfMonth(date))
                return date.AddDays(1).AddMonths(1).AddDays(-1);
            else
                return date.AddMonths(1);
        }
