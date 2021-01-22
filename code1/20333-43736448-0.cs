    static string ByteArrayToHexViaLookupPerByte2(byte[] bytes)
    {                
            var result3 = new uint[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
                    result3[i] = _Lookup32[bytes[i]];
            var handle = GCHandle.Alloc(result3, GCHandleType.Pinned);
            try
            {
                    var result = Marshal.PtrToStringUni(handle.AddrOfPinnedObject(), bytes.Length * 2);
                    return result;
            }
            finally
            {
                    handle.Free();
            }
    }
