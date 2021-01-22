        public static bool DateTimeTryParseMax(string dtText, out DateTime testDate)
        {
            testDate = DateTime.MinValue;
            string nFmt = null;
            foreach (string fmt in System.Globalization.DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns().Concat(new string[] {"yyyy", "yy"}))
            {
                if (DateTime.TryParseExact(dtText, fmt, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out testDate))
                {
                    nFmt = fmt;
                    break;
                }
            }
            if (nFmt == null)
                return false;
            nFmt = nFmt.Replace("dddd", "xxxx"); // Remove Day of the week as not helpful
            if (!nFmt.Contains("M")) testDate = testDate.AddMonths(12).AddMonths(-1);
            if (!nFmt.Contains("d")) testDate = testDate.AddMonths(1).AddDays(-1);
            if (!nFmt.Contains("h") & !nFmt.Contains("H")) testDate = testDate.AddDays(1).AddHours(-1);
            if (!nFmt.Contains("m")) testDate = testDate.AddHours(1).AddMinutes(-1);
            if (!nFmt.Contains("s")) testDate = testDate.AddMinutes(1).AddSeconds(-1);
            return true;
        }
