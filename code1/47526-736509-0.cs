    using System.Runtime.InteropServices;
    public static class User32Interop
    {
      public static char ToAscii(Keys key, Keys modifiers)
      {
        var outputBuilder = new StringBuilder(2);
        int result = ToAscii((uint)key, 0, GetKeyState(modifiers),
                             outputBuilder, 0);
        if (result == 1)
          return outputBuilder[0];
        else
          throw new Exception("Invalid key");
      }
    
      private const byte HighBit = 0x80;
      private static byte[] GetKeyState(Keys modifiers)
      {
        var keyState = new byte[256];
        foreach (Keys key in Enum.GetValues(typeof(Keys)))
        {
          if ((modifiers & key) == key)
          {
            keyState[(int)key] = HighBit;
          }
        }
        return keyState;
      }
    
      [DllImport("user32.dll")]
      private static extern int ToAscii(uint uVirtKey, uint uScanCode,
                                        byte[] lpKeyState,
                                        [Out] StringBuilder lpChar,
                                        uint uFlags);
    }
