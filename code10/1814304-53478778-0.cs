    namespace PFX
    {
        class ProcessIdPatternLayoutConverter : PatternLayoutConverter
        {
            protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
            {
                Int32 processId = Process.GetCurrentProcess().Id;
                writer.Write(processId);
            }
        }
    }
