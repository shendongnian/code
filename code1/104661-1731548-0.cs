    public IEnumerable ObjectSource(int inicio, object o) {
        Type type = o.GetType();
        object[] args = new object[] { inicio };
        object result = o.InvokeMember("FindAll", 
            BindingFlags.Default | BindingFlags.InvokeMethod, null, null, args);
        return (IEnumerable) result;
    }
