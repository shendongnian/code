    public static int FromHex(string value) {
      // strip the leading 0x
      if ( value.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) {
        value = value.Substring(2);
      }
      return Int32.Parse(value, NumberStyles.HexNumber);
    }
