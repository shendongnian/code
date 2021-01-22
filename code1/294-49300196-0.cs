        public static string TimeLeft(DateTime UTCDate)
        {
            TimeSpan timeLeft = (DateTime.UtcNow - UTCDate);
            string timeLeftString = "";
            if (timeLeft.Days > 0)
            {
                timeLeftString += timeLeft.Days + " days";
            }
            else if (timeLeft.Hours > 0)
            {
                timeLeftString += " " + timeLeft.Hours + " hours";
            }
            else
            {
                timeLeftString += timeLeft.Minutes + " minutes";
            }
            return timeLeftString;
        }
