        public static DateTimeOffset? TryParseExactDateTime(string source)
        {
            DateTimeOffset parsedDate;
            if (DateTimeOffset.TryParseExact(source, AppFormatForParsing, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return new DateTimeOffset(parsedDate.DateTime);
            }
            return null;
        }
