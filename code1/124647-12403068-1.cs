    // Data1 is "1", Data2 is "2"
    Serializer.SerializeWithLengthPrefix(ms, d1, PrefixStyle.Base128, 1);
    Serializer.SerializeWithLengthPrefix(ms, d2, PrefixStyle.Base128, 2);
    ms.Position = 0;
    var lookup = new Dictionary<int,Type> { {1, typeof(Data1)}, {2,typeof(Data2)}};
    object obj;
    while (Serializer.NonGeneric.TryDeserializeWithLengthPrefix(ms,
        PrefixStyle.Base128, fieldNum => lookup[fieldNum], out obj))
    {
        Console.WriteLine(obj); // writes Data1 on the first iteration,
                                // and Data2 on the second iteration
    }
