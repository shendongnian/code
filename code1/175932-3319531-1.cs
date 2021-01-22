        public static string ConvertDate(string arg) {
            DateTime dt;
            if (DateTime.TryParseExact(arg, "ddd MMM d HH:mm:ss yyyy", null, 
                  System.Globalization.DateTimeStyles.AssumeLocal, out dt)) {
                return dt.ToString("dd/MM/yyyy");
            }
            // Consider what to return on failure...
            return null;
        }
