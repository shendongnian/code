    private EventHandler _Changed;
    public event EventHandler Changed
    {
        add
        {
            _Changed += value;
        }
        remove
        {
            if (_Changed == null || !_Changed.GetInvocationList().Contains(value))
                throw new InvalidOperationException(
                    "Delegate is not subscribed, cannot unsubscribe");
            _Changed -= value;
        }
    }
