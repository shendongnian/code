    public class ExcelFormatCsvWriter : CsvWriter
    {
        public bool UseExcelFormat
        {
            get; set;
        }
        public ExcelFormatCsvWriter(TextWriter writer) : base(writer)
        {
        }
        public override void WriteField(string field, bool shouldQuote)
        {
            if (shouldQuote && !string.IsNullOrEmpty(field))
            {
                field = field.Replace(Context.WriterConfiguration.QuoteString, Context.WriterConfiguration.DoubleQuoteString);
            }
            if (UseExcelFormat && !string.IsNullOrEmpty(field) && field[0] == '0' && field.All(Char.IsDigit))
            {
                field = "=" + Context.WriterConfiguration.QuoteString + field + Context.WriterConfiguration.QuoteString;
            }
            else if (shouldQuote)
            {
                field = Context.WriterConfiguration.Quote + field + Context.WriterConfiguration.Quote;
            }
            Context.Record.Add(field);
        }
    }
