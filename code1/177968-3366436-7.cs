    public void ManagedFreeMemory(IntPtr dataPointer)
    {
        GCHandle dataHandle;
        byte[] data;
        if (TryUnregister(dataPointer, out dataHandle, out data)) {
            dataHandle.Free();
            // do anything with data?  I dunno...
        }
    }
