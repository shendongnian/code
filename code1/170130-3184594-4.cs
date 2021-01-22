    public sealed class HexPatternConverter : PatternLayoutConverter
    {       
        override protected void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            long id;
            if (long.TryParse(loggingEvent.ThreadName, out id))
            {
                writer.Write(id.ToString("X"));
            }
            else
            {
                writer.Write(loggingEvent.ThreadName);
            }
        }
    }
