    public void Announce<T>(T _event) where T : Event
    {
        IEnumerable<Listener<T>> listeners = Container.ResolveAll<Listener<T>>()
    
        foreach (var listener in listeners)
        {
            try
            {
                listener.Handle(_event);
    
                if (listener is IHandleSuccess<T> _listener)
                {
                    _listener.Finished(_event, listener);
                }
            }
            catch (Exception e)
            {
                // ...
            }
        }
    }
