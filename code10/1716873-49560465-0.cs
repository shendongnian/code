    using (var mmf = MemoryMappedFile.CreateFromFile(@"c:\path\to\big.file"))
    {
        using (var accessor = mmf.CreateViewAccessor())
        {
            byte myValue = accessor.ReadByte(someOffset);
            accessor.Write((byte)someValue);
        }
    }
