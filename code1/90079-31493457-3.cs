    public unsafe static dynamic ToObject(byte[] bytes)
    {
        var rf = __makeref(bytes);
        **(int**)(&rf) += 8;
        return GCHandle.Alloc(bytes).Target;
    }
