            StringBuilder time = new StringBuilder();
            TimeSpan useme = Settings.Default.WaitPeriod;
            int[] j = new int[] { useme.Hours, useme.Minutes, useme.Seconds };
            string[] single = new string[] { "hour", "minute", "second" };
            string[] multiple = new string[] { "hours", "minutes", "seconds" };
            for (int i = 0; i < j.Length; i++)
            {
                if (j[i] > 0) time.AppendFormat("{0}{1} {2}", time.Length > 0 ? " and " : "", j[i], j[i] > 1 ? multiple[i] : single[i]);
            }
            string output = String.Format("What have you been doing for the past {0} {1}?", time);
