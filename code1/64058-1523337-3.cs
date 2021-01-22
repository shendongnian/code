    <System.contextStaticAttribute()> Public WithEvents PublishEvents As EnvDTE80.PublishEvents
    
    Private Sub PublishEvents_OnPublishDone(ByVal Success As Boolean) Handles PublishEvents.OnPublishDone
        'call custom module sub here.
    End Sub
