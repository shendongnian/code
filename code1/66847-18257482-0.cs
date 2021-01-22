    private DateTime AddWorkingDays(DateTime addToDate, int numberofDays)
        {
            addToDate= addToDate.AddDays(numberofDays);
            while (addToDate.DayOfWeek == DayOfWeek.Saturday || addToDate.DayOfWeek == DayOfWeek.Sunday)
            {
                addToDate= addToDate.AddDays(1);
            }
            return addToDate;
        }
