    public static class ConvertionHelper
    {
        public static String TimeZoneAbbr(this TimeZoneInfo zone)
        {
            var zoneName = zone.Id;/* zone.IsDaylightSavingTime(DateTime.UtcNow)
                ? zone.DaylightName
                : zone.StandardName;*/
            var zoneAbbr = zoneName.CapitalLetters();
            return zoneAbbr;
        }
        public static String CapitalLetters(this String str)
        {
            return str.Transform(c => Char.IsUpper(c)
                ? c.ToString(CultureInfo.InvariantCulture)
                : null);
        }
        private static String Transform(this String src, Func<Char, String> transformation)
        {
            if (String.IsNullOrWhiteSpace(src))
            {
                return src;
            }
            var result = src.Select(transformation)
                .Where(res => res != null)
                .ToList();
            return String.Join("", result);
        }
    }
