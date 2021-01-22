    public sealed class HexPatternConverter : PatternLayoutConverter
    {       
        override protected void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            long id;
            if (long.TryParse(loggingEvent.ThreadName, out id))
            {
                writer.Write("X");
            }
            else
            {
                writer.Write(loggingEvent.ThreadName);
            }
        }
    }
