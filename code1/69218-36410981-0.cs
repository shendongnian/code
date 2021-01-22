            public static string GetDifference(DateTime d1, DateTime d2)
            {
                int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                DateTime fromDate;
                DateTime toDate;
                int year;
                int month;
                int day; 
                int increment = 0;
    
                if (d1 > d2)
                {
                    fromDate = d2;
                    toDate = d1;
                }
                else
                {
                    fromDate = d1;
                    toDate = d2;
                } 
    
                // Calculating Days
                if (fromDate.Day > toDate.Day)
                {
                    increment = monthDay[fromDate.Month - 1];
                }
    
                if (increment == -1)
                {
                    if (DateTime.IsLeapYear(fromDate.Year))
                    {
                        increment = 29;
                    }
                    else
                    {
                        increment = 28;
                    }
                }
    
                if (increment != 0)
                {
                    day = (toDate.Day + increment) - fromDate.Day;
                    increment = 1;
                }
                else
                {
                    day = toDate.Day - fromDate.Day;
                }
    
                // Month Calculation
                if ((fromDate.Month + increment) > toDate.Month)
                {
                    month = (toDate.Month + 12) - (fromDate.Month + increment);
                    increment = 1;
                }
                else
                {
                    month = (toDate.Month) - (fromDate.Month + increment);
                    increment = 0;
                }
    
                // Year Calculation
                year = toDate.Year - (fromDate.Year + increment);
    
                return year + " years " + month + " months " + day + " days";
            }
