    public bool CheckNames(NameProvider source)
    {
      IEnumerable<string> names = source.Results;
      switch(names.Count())
      {
          case 0:
            return true;//obviously none invalid.
          case 1:
            //having one name to check is a common case and for some reason
            //allows us some optimal approach compared to checking many.
            return FastCheck(names.Single());
          default:
            return NormalCheck(names)
      }
    }
