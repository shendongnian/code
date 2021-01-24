    Audit.Core.Configuration.AddCustomAction(ActionType.OnEventSaving, scope =>
    {
    	var efEvent = scope.Event.GetEntityFrameworkEvent();
    	efEvent.Entries.ForEach(e => 
    	{ 
    		e.Changes.RemoveAll(ch => ch.ColumnName == "Password");
    	});
    });
