     // First version
        public static bool TryFormat(string dateTimeString, out DateTime dateTime)
            {
                if (DateTime.TryParse(dateTimeString, out dateTime))
                {
                    return true;
                }
                return false;
            }
    // Second version , specifying the cuture as suggested by @Zohar
    public static bool TryFormat(string dateTimeString, out DateTime dateTime)
            {
                var culture = CultureInfo.CreateSpecificCulture("en-US");
                DateTimeStyles style = DateTimeStyles.None;
    
                if (DateTime.TryParse(dateTimeString, culture, style, out dateTime))
                {
                    return true;
                }
                return false;
            }
