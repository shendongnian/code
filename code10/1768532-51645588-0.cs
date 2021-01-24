       private static double DateDurationCalculate(DateTime startTime, DateTime endTime)
            {
                var usCulture = "en-US";
                startTime = DateTime.Parse(startTime.ToString("MM/dd/yyyy"), new CultureInfo(usCulture, true));
                endTime = DateTime.Parse(endTime.ToString("MM/dd/yyyy"), new CultureInfo(usCulture, true));
                TimeSpan span = endTime.Date.Subtract(startTime);
                return span.TotalDays;
            }
