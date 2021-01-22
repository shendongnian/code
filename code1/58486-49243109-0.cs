    public int ToInt(Enum e)
    {
      unchecked
      {
        if (e.GetTypeCode() == TypeCode.UInt64)
          return (int)Convert.ToUInt64(e);
        else
          return (int)Convert.ToInt64(e);
      }
    }
