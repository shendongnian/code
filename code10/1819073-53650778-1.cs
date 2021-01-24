    private readonly ConccurentQueue<QueuedTrigger> _eventQueue = new ConccurentQueue<QueuedTrigger>();
    private bool _firing;
    async Task InternalFireQueuedAsync(TTrigger trigger, params object[] args)
    {
    if (_firing)
    {
        _eventQueue.Enqueue(new QueuedTrigger { Trigger = trigger, Args = args });
        return;
    }
    try
    {
        _firing = true;
        await InternalFireOneAsync(trigger, args).ConfigureAwait(false);
        lock(_eventQueueLock)
        while (_eventQueue.Count != 0)
        {
            object queuedEvent; // change object > expected type
            if(!_eventQueue.TryDequeue())
               continue;
            await InternalFireOneAsync(queuedEvent.Trigger, queuedEvent.Args).ConfigureAwait(false);
        }
    }
    finally
    {
        _firing = false;
    }
}
