     var list = new List<string>();
                var logger = new Mock<ILogger>();
                logger
                    .Setup(l => l.Log<FormattedLogValues>(LogLevel.Warning, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<FormattedLogValues, Exception, string>>()))
                    .Callback(
                    delegate (LogLevel logLevel, EventId eventId, FormattedLogValues state, Exception exception, Func<FormattedLogValues, Exception, string> formatter)
                    {
                        list.Add(state.ToString());
                    });
