    [Guid("AAAB6710-0F2C-11d5-A53B-0010A401EB10"),
    ComImport,
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface nsICookieManager
    {
        void removeAll();
        void remove(string aDomain, string aName, string aPath, bool aBlocked);
    }
