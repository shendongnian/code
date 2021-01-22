    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            foreach (EventHandler h in handler.GetInvocationList())
            {
                var synch = h.Target as ISynchronizeInvoke;
                if (synch != null && synch.InvokeRequired)
                    synch.Invoke(h, new object[] { this, e });
                else
                    h(this, e);
            }
        }
    }
