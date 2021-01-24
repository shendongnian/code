    public static DateTime LLTimeToDateTime(string launchLibraryTime)
        {
            string[] segTime = launchLibraryTime.Split(' ');
            int monthLength = segTime[0].Length;
            int dayLength = segTime[1].Length - 1;
            string dateTimeFormatter = "";
            for (int i = 0; i < monthLength; i++)
            {
                dateTimeFormatter += "M";
            }
            dateTimeFormatter += " ";
            
            
            for (int i = 0; i < dayLength; i++)
            {
                dateTimeFormatter += "d";
            }
            dateTimeFormatter += ", yyyy HH:mm:ss";
            
            launchLibraryTime = launchLibraryTime.Substring(0, launchLibraryTime.Length - 4);
            return DateTime.ParseExact(launchLibraryTime, dateTimeFormatter,
                System.Globalization.CultureInfo.InvariantCulture);
        }
