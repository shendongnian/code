    using(Stream s = File.Create(path))
    {
        Serializer.SerializeWithLengthPrefix(s, command1, PrefixStyle.Base128, 0);
        ... your code etc
        Serializer.SerializeWithLengthPrefix(s, commandN, PrefixStyle.Base128, 0);
    }
    ...
    using(Stream s = File.OpenRead(path)) {
        foreach(Command command in
               Serializer.DeserializeItems<Command>(s, PrefixStyle.Base128, 0))
        {
           ... do something with command
        }
    }
