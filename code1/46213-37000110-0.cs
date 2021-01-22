    /// <summary>
    /// Returns the character associated with the specified character code.
    /// </summary>
    /// 
    /// <returns>
    /// Returns the character associated with the specified character code.
    /// </returns>
    /// <param name="CharCode">Required. An Integer expression representing the <paramref name="code point"/>, or character code, for the character.</param><exception cref="T:System.ArgumentException"><paramref name="CharCode"/> &lt; 0 or &gt; 255 for Chr.</exception><filterpriority>1</filterpriority>
    public static char Chr(int CharCode)
    {
      if (CharCode < (int) short.MinValue || CharCode > (int) ushort.MaxValue)
        throw new ArgumentException(Utils.GetResourceString("Argument_RangeTwoBytes1", new string[1]
        {
          "CharCode"
        }));
      if (CharCode >= 0 && CharCode <= (int) sbyte.MaxValue)
        return Convert.ToChar(CharCode);
      try
      {
        Encoding encoding = Encoding.GetEncoding(Utils.GetLocaleCodePage());
        if (encoding.IsSingleByte && (CharCode < 0 || CharCode > (int) byte.MaxValue))
          throw ExceptionUtils.VbMakeException(5);
        char[] chars = new char[2];
        byte[] bytes = new byte[2];
        Decoder decoder = encoding.GetDecoder();
        if (CharCode >= 0 && CharCode <= (int) byte.MaxValue)
        {
          bytes[0] = checked ((byte) (CharCode & (int) byte.MaxValue));
          decoder.GetChars(bytes, 0, 1, chars, 0);
        }
        else
        {
          bytes[0] = checked ((byte) ((CharCode & 65280) >> 8));
          bytes[1] = checked ((byte) (CharCode & (int) byte.MaxValue));
          decoder.GetChars(bytes, 0, 2, chars, 0);
        }
        return chars[0];
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// Returns an Integer value representing the character code corresponding to a character.
    /// </summary>
    /// 
    /// <returns>
    /// Returns an Integer value representing the character code corresponding to a character.
    /// </returns>
    /// <param name="String">Required. Any valid Char or String expression. If <paramref name="String"/> is a String expression, only the first character of the string is used for input. If <paramref name="String"/> is Nothing or contains no characters, an <see cref="T:System.ArgumentException"/> error occurs.</param><filterpriority>1</filterpriority>
    public static int Asc(char String)
    {
      int num1 = Convert.ToInt32(String);
      if (num1 < 128)
        return num1;
      try
      {
        Encoding fileIoEncoding = Utils.GetFileIOEncoding();
        char[] chars = new char[1]
        {
          String
        };
        if (fileIoEncoding.IsSingleByte)
        {
          byte[] bytes = new byte[1];
          fileIoEncoding.GetBytes(chars, 0, 1, bytes, 0);
          return (int) bytes[0];
        }
        byte[] bytes1 = new byte[2];
        if (fileIoEncoding.GetBytes(chars, 0, 1, bytes1, 0) == 1)
          return (int) bytes1[0];
        if (BitConverter.IsLittleEndian)
        {
          byte num2 = bytes1[0];
          bytes1[0] = bytes1[1];
          bytes1[1] = num2;
        }
        return (int) BitConverter.ToInt16(bytes1, 0);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// Returns an Integer value representing the character code corresponding to a character.
    /// </summary>
    /// 
    /// <returns>
    /// Returns an Integer value representing the character code corresponding to a character.
    /// </returns>
    /// <param name="String">Required. Any valid Char or String expression. If <paramref name="String"/> is a String expression, only the first character of the string is used for input. If <paramref name="String"/> is Nothing or contains no characters, an <see cref="T:System.ArgumentException"/> error occurs.</param><filterpriority>1</filterpriority>
    public static int Asc(string String)
    {
      if (String == null || String.Length == 0)
        throw new ArgumentException(Utils.GetResourceString("Argument_LengthGTZero1", new string[1]
        {
          "String"
        }));
      return Strings.Asc(String[0]);
    }
