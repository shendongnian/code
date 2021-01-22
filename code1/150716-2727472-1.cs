    var ctx = new EventManagerDomainContext();
    ctx.Events.Add(newEvent);
    ctx.SubmitChanges(delegate(Operation op)
    {
        if (!op.HasError)
        {
            NavigateToEditEvent(newEvent.EventID);
        }
    }, null);
