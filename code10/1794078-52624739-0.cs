                DateTime startDay = DateTime.Now.Date;
                DateTime endDay = startDay.AddDays(1);
                int intervalMinutes = 60;
                 DateTime  timeCounter = startDay;
                 List<DateTime> intervals = new List<DateTime>();
                 while (timeCounter < endDay)
                 {
                     intervals.Add(timeCounter);
                     timeCounter = timeCounter.AddMinutes(intervalMinutes);
                 }
