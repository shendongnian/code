    public class MyCustomBuildLogger : ILogger
    {
        private IEventSource source;
     
     public void Initialize(IEventSource eventSource)
            {
                this.source = eventSource;
                //Events.ProjectStarted += new ProjectStartedEventHandler(Events_ProjectStarted);
                //Events.ProjectFinished += new ProjectFinishedEventHandler(Events_ProjectFinished);
                Events.WarningRaised += new BuildWarningEventHandler(Events_WarningRaised);
                Events.ErrorRaised += new BuildErrorEventHandler(Events_ErrorRaised);
                Events.BuildFinished += new BuildFinishedEventHandler(Events_BuildFinished);
                //Events.BuildStarted += new BuildStartedEventHandler(Events_BuildStarted);
                Events.MessageRaised += new BuildMessageEventHandler(Events_MessageRaised);
                //Events.CustomEventRaised += new CustomBuildEventHandler(Events_CustomEventRaised);
    
                Events.MessageRaised += new BuildMessageEventHandler(Events_MessageRaised);
            }
    
     void Events_ErrorRaised(object sender, BuildErrorEventArgs e)
            {
                // This logs the error to VS Error List tool window
                Log.LogError(String.Empty, 
       
                 String.Empty,
                        String.Empty, 
                        e.File, 
                        e.LineNumber, 
                        e.ColumnNumber,
                        e.LineNumber, 
                        e.ColumnNumber, 
                        e.Message);
               }
    }
