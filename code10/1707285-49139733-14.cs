    var iSerializable = a1 as ISerializable;
    if (iSerializable != null)
    {
        var info = new SerializationInfo(a1.GetType(), new FormatterConverter());
        var initialFullTypeName = info.FullTypeName;
        iSerializable.GetObjectData(info, new StreamingContext(StreamingContextStates.All));
        Console.WriteLine("Initial FullTypeName = \"{0}\", final FullTypeName = \"{1}\".", initialFullTypeName, info.FullTypeName);
        var enumerator = info.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine("   Name = {0}, objectType = {1}, value = {2}.", enumerator.Name, enumerator.ObjectType, enumerator.Value);
        }
    }
