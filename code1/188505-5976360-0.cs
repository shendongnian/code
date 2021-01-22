    [Flags]
    enum SomeType : byte {
      Value = 2,
    }
    public void Method () {
      SomeType t = 0;
      t |= SomeType.Value;
      t &= ~SomeType.Value;
    }
