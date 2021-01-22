    public override string ToString(string format)
    {
      StringBuilder s = new StringBuilder();
      foreach (char c in format)
      {
        switch (c)
        {
          case 'E':
            s.Append(EquipID);
            break;
          case 'D':
            s.Append(EquipDesc);
            break;
          case 'I':
            s.Append(DepartID);
            break;
          default:
            s.Append(c);
            break;
        }
      }
      return s.ToString();
    }
  
