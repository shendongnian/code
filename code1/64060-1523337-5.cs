    <System.contextStaticAttribute()> Public WithEvents PublishEvents As EnvDTE80.PublishEvents
    
    Private Sub PublishEvents_OnPublishDone(ByVal Success As Boolean) Handles PublishEvents.OnPublishDone
       CustomMacros.runExternalCommandOnComplete = False
       'Where ExternalCommand1 matches the command you want to run
       DTE.ExecuteCommand("Tools.ExternalCommand1")  
    End Sub
