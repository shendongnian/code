        private static DateTime PickRandomMinute(int inPastNDays, Random random)
        {
            DateTime today = DateTime.Today;
            int totalMinutes = (int)(today - today.AddDays(-inPastNDays)).TotalMinutes;
            return today.AddDays(-inPastNDays).AddMinutes(random.Next(totalMinutes));
        }
