    public static class Externders
    {
        public static bool TryParse(this Nullable<DateTime> nDate, string text)
        {
            DateTime date = DateTime.MinValue;
            if (DateTime.TryParse(text, out date))
            {
                nDate = date;
                return true;
            }
            return false;
        }
    }
