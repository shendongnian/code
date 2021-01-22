    public struct IPV4Address
    {
      private UInt32 _Value;
      private UInt32 _Mask;
      public UInt32 Value
      {
        get { return _Value; }
        private set { _Value = value; }
      }
      public UInt32 Mask
      {
        get { return _Mask; }
        private set { _Mask = value; }
      }
      public static IPV4Address FromString(string address)
      {
        return FromString(address, 32);
      }
      public static IPV4Address FromString(string address, int maskLength)
      {
        string[] parts = address.Split('.');
        UInt32 value = ((UInt32.Parse(parts[0]) << 24) +
          ((UInt32.Parse(parts[1])) << 16) +
          ((UInt32.Parse(parts[2])) << 8) +
          UInt32.Parse(parts[3]));
        return new IPV4Address(value, maskLength);
      }
      public IPV4Address(UInt32 value)
      {
        _Value = value;
        _Mask = int.MaxValue;
      }
      public IPV4Address(UInt32 value, int maskLength)
      {
        if (maskLength < 0 || maskLength > 32)
          throw new ArgumentOutOfRangeException("maskLength", "Must be 0 to 32");
        _Value = value;
        if (maskLength == 32)
          _Mask = UInt32.MaxValue;
        else
          _Mask = ~(UInt32)((1 << (32 - maskLength))-1);
        if ((_Value & _Mask) != _Value)
          throw new ArgumentException("Address value must be contained in mask");
      }
      public bool Contains(IPV4Address address)
      {
        if ((Mask & address.Mask) == Mask)
        {
          return (address.Value & Mask) == Value;
        }
        return false;
      }
      public override string ToString()
      {
        string result = String.Format("{0}.{1}.{2}.{3}", (_Value >> 24), 
          (_Value >> 16) & 0xFF, 
          (_Value >> 8) & 0xFF, 
          _Value & 0xFF);
        if (_Mask != UInt32.MaxValue)
          result += "/" + String.Format("{0}.{1}.{2}.{3}", (_Mask >> 24),
          (_Mask >> 16) & 0xFF,
          (_Mask >> 8) & 0xFF,
          _Mask & 0xFF);
        
        return result;
      }
    }
