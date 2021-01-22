    private List<WeakReference> _eventRefs = new List<WeakReference>();
    public event EventHandler SomeEvent
    {
        add
        {
            _eventRefs.Add(new WeakReference(value));
        }
        remove
        {
            for (int i = 0; i < _eventRefs; i++)
            {
                var wRef = _eventRefs[i];
                if (!wRef.IsAlive)
                {
                    _eventRefs.RemoveAt(i);
                    i--;
                    continue;
                }
                var handler = wRef.Target as EventHandler;
                if (object.ReferenceEquals(handler, value))
                {
                    _eventRefs.RemoveAt(i);
                    i--;
                    continue;
                }
            }
        }
    }
