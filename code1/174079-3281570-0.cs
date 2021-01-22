    private static readonly Dictionary<int, MyEnum> _dict = new Dictionary<int, MyEnum> {
       {1, MyEnum.field1},
       {2, MyEnum.field2},
       {3, MyEnum.field3}
    };
    public MyEnum GetIt(int val)
    {
      if (!_dict.ContainsKey(val)) throw new ArgumentException("val");
      return _dict[val];
    }
