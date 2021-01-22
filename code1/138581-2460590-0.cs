        public sealed class MyBufferingAppender: BufferingAppenderSkeleton
        {
            public MyBufferingAppender()
            {
                BufferSize = 3;
                ActivateOptions();
            }
            public readonly List<LoggingEvent> SentEvents = new List<LoggingEvent>();
            protected override void SendBuffer(LoggingEvent[] events)
            {
                SentEvents.AddRange(events);
            }
        }
