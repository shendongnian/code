    public static bool IsDefined(this Enum value)
    {
      dynamic dyn = value;
      var max = Enum.GetValues(value.GetType()).Cast<dynamic>().
        Aggregate((e1,e2) =>  e1 | e2);
      return (max & dyn) == dyn;
    }
