    TimeSpan ts = DateTime.Now - User.LastPasswordSet.Value;
            double days = ts.TotalDays;
            if (days >= 1)
            {
                //A day has passed.
            }
