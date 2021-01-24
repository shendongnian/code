    public static DateTime AddWorkdays(this DateTime originalDate, int workDays)
            {
                DateTime tmpDate = originalDate;
                while (workDays > 0)
                {
                    tmpDate = tmpDate.AddDays(1);
                    if (tmpDate.DayOfWeek == DayOfWeek.Saturday ||  
                        tmpDate.DayOfWeek == DayOfWeek.Sunday )
                        workDays--;
                }
                return tmpDate;
            }
-----
    DateTime endDate = startDate.AddWorkdays(15);
