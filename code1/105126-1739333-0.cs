    SynchronizationContext context =
        SynchronizationContext.Current ?? new SynchronizationContext();
    context.Send(s =>
        {
            // your code here
        }, null);
