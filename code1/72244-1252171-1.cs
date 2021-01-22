    public class wxDateTimeConvert
    {
        /// <summary>
        /// Gets the javascript short date pattern.
        /// </summary>
        /// <param name="dateTimeFormat">The date time format.</param>
        /// <returns></returns>
        public static string GetJavascriptShortDatePattern(DateTimeFormatInfo dateTimeFormat)
        {
            return dateTimeFormat.ShortDatePattern
                .Replace("MM", "mm")
                .Replace("M", "m")
                .Replace("yy", "y");
        }
    }
