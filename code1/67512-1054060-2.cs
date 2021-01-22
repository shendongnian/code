    private void CallTheMethod(MemoryStream memStream)
    {
       byte[] rawData = new byte[memStream.Length];
       memStream.Read(rawData, 0, memStream.Length);
       
       GCHandle rawDataHandle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
       IntPtr address = handle.AddrOfPinnedObject ();
       doSomething(address, rawData.Length);
       rawDataHandle.Free();
     }
