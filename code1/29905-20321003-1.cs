    // using System.Runtime.InteropServices
    unsafe byte[] GetRawBytes(String s)
    {
        if (s == null) return null;
        var codeunitCount = s.Length;
        /* We know that String is a sequence of UTF-16 codeunits 
           and such codeunits are 2 bytes */
        var byteCount = codeunitCount * 2; 
        var bytes = new byte[byteCount];
        fixed(void* pRaw = s)
        {
            Marshal.Copy((IntPtr)pRaw, bytes, 0, byteCount);
        }
        return bytes;
    }
