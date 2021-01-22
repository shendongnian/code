        static private readonly string[] MostCommonDateStringFormatsFromWeb = {
            "u", //universal sortable   2008-04-10T06:30:00Z          this is default format employed by moment().utc().format()
            "yyyy'-'MM'-'dd'T'hh:mm:ss.fffZ", //2008-04-10T06:30:00.000Z   retard string format for dates that syncfusion libs churn out when invoked by ejgrid for odata filtering and so on
            "O", //iso8601              2008-04-10T06:30:00.0000000
            "s", //sortable             2008-04-10T06:30:00
        };
        static public bool TryParseWebDateStringExactToUTC(
            out DateTime date,
            string input,
            string[] formats = null,
            DateTimeStyles? styles = null,
            IFormatProvider formatProvider = null
        )
        {
            formats = formats ?? MostCommonDateStringFormatsFromWeb;
            return TryParseDateStringExactToUTC(out date, input, formats, styles, formatProvider);
        }
        static public bool TryParseDateStringExactToUTC(
            out DateTime date,
            string input,
            string[] formats = null,
            DateTimeStyles? styles = null,
            IFormatProvider formatProvider = null
        )
        {
            styles = styles ?? DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.RoundtripKind; //0 utc
            formatProvider = formatProvider ?? CultureInfo.InvariantCulture;
            var verdict = DateTime.TryParseExact(input, result: out date, style: styles.Value, formats: formats, provider: formatProvider);
            
            return verdict;
            //0 employing roundtripkind is vital in order for the resulting date to be in utc when the 'Z' flag is employed at the end of the input string
            //  like for instance in   2008-04-10T06:30.000Z
        }
