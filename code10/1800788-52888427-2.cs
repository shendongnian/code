    public void Announce(Foo _event)
    {
        IEnumerable<Listener<Foo>> listeners = Container.ResolveAll<Listener<Foo>>()
    
        foreach (var listener in listeners)
        {
            try
            {
                listener.Handle(_event);
    
                if (listener is IHandleSuccess<Foo> _listener)
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
