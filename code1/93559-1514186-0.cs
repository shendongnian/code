    public char Convert(string data) {
      data = data.SubString(1);  // Lose the &
      var num = Int32.Parse(data, NumberStyles.Hex | NumberStyles.AllowHexSpecifier);
      var chars = Encoding.ASCII.GetChars(new byte[] { (byte)num });
      return chars[0];
    }
