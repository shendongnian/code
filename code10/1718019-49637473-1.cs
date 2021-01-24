    private void OnPropertyChanged(string name)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            if (syncronzeInvoke != null && syncronzeInvoke.InvokeRequired)
                syncronzeInvoke.Invoke(handler, new object[] 
                    { this, new PropertyChangedEventArgs(name) });
            else
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
