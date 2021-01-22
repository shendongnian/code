    public static int FromHex(string value) {
      if ( value.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) {
        value = value.SubString(2);
      }
      return Int32.Parse(value, NumberStyles.HexNumber);
    }
