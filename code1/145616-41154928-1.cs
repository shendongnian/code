    public class ActorSynchronizationContext : SynchronizationContext
    {
        private readonly SynchronizationContext _subContext;
        private readonly ConcurrentQueue<Action> _pending = new ConcurrentQueue<Action>();
        private int _pendingCount;
        public ActorSynchronizationContext(SynchronizationContext context = null)
        {
            this._subContext = context ?? new SynchronizationContext();
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            if (d == null) {
                throw new ArgumentNullException("SendOrPostCallback");
            }
            _pending.Enqueue(() => d(state));
            if (Interlocked.Increment(ref _pendingCount) == 1)
            {
                try
                {
                    _subContext.Post(Consume, null); 
                }
                catch (Exception exp)
                {
                    LogHelper.LogUnhandleException(exp.ToString());
                }
            }
        }
        private void Consume(object state)
        {
            var surroundContext = Current;
            SetSynchronizationContext(this);
            do
            {
                Action a;
                _pending.TryDequeue(out a);
                try
                {
                    a.Invoke();
                }
                catch (Exception exp)
                {
                    //Debug.LogError(exp.ToString());
                    LogHelper.LogUnhandleException(exp.ToString());
                }
            } while (Interlocked.Decrement(ref _pendingCount) > 0);
            SetSynchronizationContext(surroundContext);
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException();
        }
        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
    }
