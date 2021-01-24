    internal static DateTime ChangeDateFormat(string dateAdded)
        {
           
            return ParseDateTime(DateTime.Now.ToString("dd-MM-yyyy hh:mm"), DateTimeFormats);
        }
     private static DateTime ParseDateTime(string dateTimeString, string[] formats)
        {
            try
            {
                DateTime dateStamp = DateTime.ParseExact(dateTimeString,
                    formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
                return dateStamp;
            }
            catch (Exception exe)
            {
                var message = $"dateTimeString: '{dateTimeString}', '{string.Join(",", formats)}'.";
                Utility.log(message);
                throw;
            }
        }
