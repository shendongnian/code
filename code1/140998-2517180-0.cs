    public bool TryParseNullableBool (string value, out bool? result)
    {
      result = false;
      if (string.IsNullOrEmpty (value))
      {
        result = null;
        return true;
      }
      else
      {
        bool r;
        if (bool.TryParse (value, out r))
        {
          result = r;
          return true;
        }
      }
      return false;
    }
