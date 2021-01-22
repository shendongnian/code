    public IEnumerable ObjectSource(int inicio, object o) {
        Type type = o.GetType();
        object[] args = new object[] { inicio };
        object result = type.InvokeMember("FindAll", 
            BindingFlags.Default | BindingFlags.InvokeMethod, null, o, args);
        return (IEnumerable) result;
    }
