    private DateTime AddMonthsRetainingEOM(DateTime someDate, int numMonths)
        {
            if (someDate.AddDays(1).Day == 1)
            {
                // someDate is EOM
                someDate = someDate.AddMonths(numMonths);
                // keep adding days if new someDate is not EOM
                while (someDate.AddDays(1).Day != 1)
                {
                    someDate = someDate.AddDays(1);
                }
                return someDate;
            }
            else
            {
                // not EOM - Just add months
                return someDate.AddMonths(numMonths);
            }
        }
