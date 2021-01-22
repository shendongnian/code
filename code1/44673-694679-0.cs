    [DllImport("ICE_API.DLL", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
    public static extern bool GetCardStatus(CARDIDTYPE CardId, UInt32 level, IntPtr pData, UInt32 cbBuf, out UInt32 pcbNeeded);
    
    public void Example(uint size) {
      // Get other params
      var ptr = Marshal.AllocHGlobal(size);
      GetCardStatus(cardId, level, ptr, size, out needed);
      // Marshal back the byte array here
      Marshal.FreeHGlobal(ptr);
    }
