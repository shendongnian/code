         public string SumHours(string TimeIn, string TimeOut)
        {
            var parts = TimeIn.Split(':');
            var hours = Int32.Parse(parts[0]);
            var minutes = Int32.Parse(parts[1]);
            var result = new TimeSpan(hours, minutes, 0);
            TimeIn = result.ToString();
            TimeSpan Hour1 = TimeSpan.Parse(TimeIn);
            TimeSpan Hour2 = TimeSpan.Parse(TimeOut);
            Hour1 = Hour1.Add(Hour2);
            string HourtoStr = string.Format("{0:D2}:{1:D2}:{2:D2}", (Hour1.Days * 24 + Hour1.Hours), Hour1.Minutes, Hour1.Seconds);
            return HourtoStr;
        }
