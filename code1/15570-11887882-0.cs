            if (!string.IsNullOrEmpty(jsonTime) && jsonTime.IndexOf("Date") > -1)
            {
                string milis = jsonTime.Substring(jsonTime.IndexOf("(") + 1);
                string sign = milis.IndexOf("+") > -1 ? "+" : "-";
                string hours = milis.Substring(milis.IndexOf(sign));
                milis = milis.Substring(0, milis.IndexOf(sign));
                hours = hours.Substring(0, hours.IndexOf(")"));
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToInt64(milis)).AddHours(Convert.ToInt64(hours) / 100);                 
            }
           
            return DateTime.Now;
        }
