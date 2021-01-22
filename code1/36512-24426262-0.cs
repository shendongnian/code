     public static string SpanToReadableTime(TimeSpan span)
        {
            string[] values = new string[4];  //4 slots: days, hours, minutes, seconds
            StringBuilder readableTime = new StringBuilder();
            if (span.Days > 0)
            {
                if (span.Days == 1)
                    values[0] = span.Days.ToString() + " dag"; //day
                else
                    values[0] = span.Days.ToString() + " dagen";  //days
                readableTime.Append(values[0]);
                readableTime.Append(", ");
            }
            else
                values[0] = String.Empty;
            if (span.Hours > 0)
            {
                if (span.Hours == 1)
                    values[1] = span.Hours.ToString() + " uur";  //hour
                else
                    values[1] = span.Hours.ToString() + " uren";  //hours
                readableTime.Append(values[1]);
                readableTime.Append(", ");
            }
            else
                values[1] = string.Empty;
            if (span.Minutes > 0)
            {
                if (span.Minutes == 1)
                    values[2] = span.Minutes.ToString() + " minuut";  //minute
                else
                    values[2] = span.Minutes.ToString() + " minuten";  //minutes
                readableTime.Append(values[2]);
                readableTime.Append(", ");
            }
            else
                values[2] = string.Empty;
            if (span.Seconds > 0)
            {
                if (span.Seconds == 1)
                    values[3] = span.Seconds.ToString() + " seconde";  //second
                else
                    values[3] = span.Seconds.ToString() + " seconden";  //seconds
                readableTime.Append(values[3]);
            }
            else
                values[3] = string.Empty;
            return readableTime.ToString();
        }//end SpanToReadableTime
