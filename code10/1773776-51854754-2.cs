    public class AzureLogAppender : AppenderSkeleton
        {
            //Logger object.
            private Logger objLogger = null;
    
            //Azure table name.
            public string tableName { get; set; }
    
            //Azure account name.
            public string accountName { get; set; }
    
            //Azure account key.
            public string accountKey { get; set; }
    
            public override void ActivateOptions()
            {
                base.ActivateOptions();
    
                //Logger object.
                if (objLogger == null)
                {
                    //Intilize logger object.
                    this.objLogger = new Logger(tableName, accountName, accountKey);
                }
            }
    
            protected override void Append(LoggingEvent loggingEvent)
            {
                try
                {
                    //Intilize AzureLog object.
                    AzureLog objAzureLog = new AzureLog
                                        {
                                            RoleInstance = "1",
                                            DeploymentId = "100", 
                                            Message = loggingEvent.RenderedMessage,
                                            Level = loggingEvent.Level.Name,
                                        };
    
                    //Insert the log.
                    objLogger.Insert(objAzureLog);
                }
                catch (Exception ex)
                {
                    //Handle exception here.
                }
            }
        }
