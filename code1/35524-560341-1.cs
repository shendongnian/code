    public void NewThread(string name)
    {
        MethodInfo method = GetType().GetMethod(name,
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            null, Type.EmptyTypes, null);
        ThreadStart starter = delegate { method.Invoke(this, null); };
        // etc (note: no point using Delegate.CreateDelegate for a 1-call usage
