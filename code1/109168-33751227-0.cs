    private int GetWeekdayCount(DayOfWeek dayOfWeek, DateTime begin, DateTime end)
        {
            if (begin < end)
            {
                var timeSpan = end.Subtract(begin);
                var fullDays = timeSpan.Days;
                var count = fullDays / 7; // количество дней равно как минимум количеству полных недель попавших в диапазон
                var remain = fullDays % 7; // остаток от деления
                // и вычислим попал ли еще один день в те куски недели, что остаются от полной
                if (remain > 0)
                {
                    var dowBegin = (int)begin.DayOfWeek;
                    var dowEnd = (int)end.DayOfWeek;
                    var dowDay = (int)dayOfWeek;
                    if (dowBegin < dowEnd)
                    {
                        // когда день недели начала меньше дня недели конца, например:
                        //  начало       конец
                        //    \/          \/
                        //    -- -- -- -- --
                        // Вс Пн Вт Ср Чт Пт Сб
                        if (dowDay >= dowBegin && dowDay <= dowEnd)
                            count++;
                    }
                    else
                    {
                        // когда день недели начала больше дня недели конца, например:
                        //   конец      начало
                        //    \/          \/
                        // -- --          -- --
                        // Вс Пн Вт Ср Чт Пт Сб
                        if (dowDay <= dowEnd || dowDay >= dowBegin)
                            count++;
                    }
                }
                else if (begin.DayOfWeek == dayOfWeek)
                    count++;
                return count;
            }
            return 0;
        }
