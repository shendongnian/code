    bool IsUpdateSharedDataOverridden()
    {
        Type t = this.GetType();
        MethodInfo m = subType.GetMethod("UpdateSharedData");
        return m.DeclaringType.Name == t.Name;
    }
