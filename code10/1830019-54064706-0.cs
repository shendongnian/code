    public class MealCalculation
        {
            int countA, countB, countC = 0;
            int total = 0;
            public void Calculate()
            {
                var start = DateTime.Now;
                var finish = DateTime.Now;
                // Same Day
                if (start.Date == finish.Date)
                {
                    MealsCalculate(start.Hour, start.Hour);
                }
                // Next Day
                else if (start.AddDays(1).Date == finish.Date)
                {
                    MealsCalculate(start.Hour, 24);
                    MealsCalculate(0, finish.Hour);
                }
                // Great Than 1 Day
                else
                {
                    // First Day
                    MealsCalculate(start.Hour, 24);
                    // Middle Full Days
                    var days = NumberOfDays(start.Date, finish.Date);
                    countA += days;
                    countB += days;
                    countC += days;
                    // Finish Day
                    MealsCalculate(0, finish.Hour);
                }
                // Total
                total = countA + countB + countC;
            }
            public int NumberOfDays(DateTime start, DateTime finish)
            {
                var days = 0;
                while (start < finish)
                {
                    start.AddDays(1);
                    days++;
                }
                return days - 1;
            }
            public void MealsCalculate(int totalHoursArrived, int totalHoursExit)
            {
                if (totalHoursArrived <= 8 && totalHoursExit >= 17) //if date is before or on 8AM and leaves on or after 5PM.
                {
                    countA += 1;
                    countB += 1;
                    countC += 1;
                }
                else if (totalHoursArrived <= 8 && (totalHoursExit >= 12 && totalHoursExit < 17)) //if date is before or on 8AM and leaves before 5PM
                {
                    countA += 1;
                    countB += 1;
                }
                else if (totalHoursArrived <= 8 && totalHoursExit < 12) //if date is before or on 8AM and leaves before 12PM
                {
                    countA += 1;
                }
                else if ((totalHoursArrived <= 12 && totalHoursArrived > 8) && totalHoursExit >= 17) //if date is before or on 12PM and leaves on or after 5PM
                {
                    countB += 1;
                    countC += 1;
                }
                else if ((totalHoursArrived <= 12 && totalHoursArrived > 8) && totalHoursExit < 17) //if date is before or on 12PM and leaves before 5PM
                {
                    countB += 1;
                }
                else if (totalHoursArrived >= 17) //if date is after or on 5PM
                {
                    countC += 1;
                }
            }
        }
