    protected virtual void OnChanged(string info)   // the Trigger
    {
        var args = new MyEventArgs{Info = info};    // this part will vary
        Changed?.Invoke(this, args);
    }
