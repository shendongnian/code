    bool IsUpdateSharedDataOverridden()
    {
        Type t = this.GetType();
        MethodInfo m = subType.GetMethod("UpdateSharedData");
        return m.IsVirtual && m.DeclaringType == t;
    }
