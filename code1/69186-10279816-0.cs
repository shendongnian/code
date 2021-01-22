            DateTime todaysDate = DateTime.Now;
            DateTime interimDate = originalDate;
            ///Find Year diff
            int yearDiff = System.Data.Linq.SqlClient.SqlMethods.DateDiffYear(interimDate, todaysDate);
            interimDate = interimDate.AddYears(yearDiff);
            if (interimDate > todaysDate)
            {
                yearDiff -= 1;
                interimDate = interimDate.AddYears(-1);
            }
            ///Find Month diff
            int monthDiff = System.Data.Linq.SqlClient.SqlMethods.DateDiffMonth(interimDate, todaysDate);
            interimDate = interimDate.AddMonths(monthDiff);
            if (interimDate > todaysDate)
            {
                monthDiff -= 1;
                interimDate = interimDate.AddMonths(-1);
            }
            ///Find Day diff
            int daysDiff = System.Data.Linq.SqlClient.SqlMethods.DateDiffDay(interimDate, todaysDate);
