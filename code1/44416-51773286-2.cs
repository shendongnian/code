    > var k1 =  Tuple.Create("test", int.MinValue, DateTime.MinValue, double.MinValue);
    > var k2 = Tuple.Create("test", int.MinValue, DateTime.MinValue, double.MinValue);
    > var dict = new Dictionary<object, object>();
    > dict.Add(k1, "item");
    > dict.Add(k2, "item");
    An item with the same key has already been added....
    > dict[k1] == dict[k2]
    true
