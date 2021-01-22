        public static string TimeSpanToString(this TimeSpan timeSpan)
        {
            //if it's negative
            if (timeSpan.Ticks < 0)
            {
                timeSpan = timeSpan - timeSpan - timeSpan;
                if (timeSpan.Days != 0)
                    return string.Format("-{0}:{1}", timeSpan.Days.ToString("d"), new DateTime(timeSpan.Ticks).ToString("HH:mm:ss"));
                else
                    return new DateTime(timeSpan.Ticks).ToString("-HH:mm:ss");
            }
            //if it has days
            else if (timeSpan.Days != 0)
                return string.Format("{0}:{1}", timeSpan.Days.ToString("d"), new DateTime(timeSpan.Ticks).ToString("HH:mm:ss"));
            //otherwise return the time
            else
                return new DateTime(timeSpan.Ticks).ToString("HH:mm:ss");
        }
