    public class DateFormatChoice {
        public string FormatCode { get; private set; }
        public string CurrentDateExample {
            get { return DateTime.Now.ToString( FormatCode ) }
        }
        
        public DateFormatChoice( string standardcode ) {
            FormatCode = standardcode;
        }
    }
