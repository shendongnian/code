    > var k1 =  ValueTuple.Create("test", int.MinValue, DateTime.MinValue, double.MinValue);
    > var k2 = ValueTuple.Create("test", int.MinValue, DateTime.MinValue, double.MinValue);
    > var dict = new Dictionary<object, object>();
    > dict.Add(k1, "item");
    > dict.Add(k2, "item");
    An item with the same key has already been added.
      + System.ThrowHelper.ThrowArgumentException(System.ExceptionResource)
      + Dictionary<TKey, TValue>.Insert(TKey, TValue, bool)
      + Dictionary<TKey, TValue>.Add(TKey, TValue)
    > dict[k1] == dict[k2]
    true
