public static class Timex
    {
        public static string GetDate(this string JDate)
        {
            if (JDate == null)
            {               
                return "";
            }
            var JDate = DBDate.Split(null);                        
            return DateTime.ParseExact(JDate[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
}
