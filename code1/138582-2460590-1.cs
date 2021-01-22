        [Test]
        public void DoAppend_BuffersEvents()
        {
            var appender = new MyBufferingAppender();
            appender.DoAppend(new LoggingEvent(
               new LoggingEventData {Level = Level.Error, Message = "Hello world"}));
            Assert.That(appender.SentEvents, Has.Count(0));
        }
