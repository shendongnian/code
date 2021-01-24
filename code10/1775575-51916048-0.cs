    public static bool TryFormat(string dateTimeString, out DateTime dateTime)
        {
            if (DateTime.TryParse(dateTimeString, out dateTime))
            {
                return true;
            }
            return false;
        }
