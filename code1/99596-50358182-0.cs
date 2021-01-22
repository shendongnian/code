            foreach (DateTime day in EachDay(model))
            {
                bool key = false;
                foreach (LeaveModel ln in holidaycalendar)
                {
                    if (day.Date == ln.Date && day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                    {
                        key = true; break;
                    }
                }
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    key = true;
                }
                if (key != true)
                {
                    leavecount++;
                }
            }
         
