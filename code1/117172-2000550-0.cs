        private static DateTime ParseDate(string s)
        {
            DateTime result;
            if (!DateTime.TryParse(s, out result))
            {                
                result = DateTime.ParseExact(s, "yyyy-MM-ddT24:mm:ssK", System.Globalization.CultureInfo.InvariantCulture);
                result = result.AddDays(1);
            }
            return result;
        }
