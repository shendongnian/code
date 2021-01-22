    public delegate void CallbackDelegate(string status);
    public void DoWork(string param, CallbackDelegate callback)
    {
        callback("status");
    }
