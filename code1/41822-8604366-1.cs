     public int getMonth(int weekNum, int year)
            {
                DateTime Current = new DateTime(year, 1, 1);
                System.DayOfWeek StartDOW = Current.DayOfWeek;
                int DayOfYear = (weekNum * 7) - 6; //1st day of the week
                
                if (StartDOW != System.DayOfWeek.Sunday) //means that last week of last year's month
                {
                    Current = Current.AddDays(7 - (int)Current.DayOfWeek);
                }
                return Current.AddDays(DayOfYear).Month;
            }
