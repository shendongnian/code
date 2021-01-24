    private readonly Queue<QueuedTrigger> _eventQueue = new Queue<QueuedTrigger>();
    private bool _firing;
    private object _eventQueueLock = new object();
    async Task InternalFireQueuedAsync(TTrigger trigger, params object[] args)
    {
    if (_firing)
    {
        lock(_eventQueueLock)
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
            var queuedEvent = _eventQueue.Dequeue();
            await InternalFireOneAsync(queuedEvent.Trigger, queuedEvent.Args).ConfigureAwait(false);
        }
    }
    finally
    {
        _firing = false;
    }
