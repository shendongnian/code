    static void PatchFile(FileInfo source, FileInfo target
        , IList<byte> searchPattern, IList<byte> replacementPattern)
    {
        if (searchPattern.Count != replacementPattern.Count)
            throw new Exception("PatchFile can only replace a pattern with one of equal length.");
        using (var input = new BinaryReader(source.OpenRead()))
        using (var output = new BinaryWriter(target.OpenWrite()))
        {
            var matchPos = 0;
            while (input.BaseStream.Position < input.BaseStream.Length)
            {
                var b = input.ReadByte();
                if (b != searchPattern[matchPos])
                {
                    for (var i = 0; i < matchPos; i++)
                        output.Write(searchPattern[i]);
                    output.Write(b);
                    matchPos = 0;
                }
                if (b == searchPattern[matchPos])
                {
                    matchPos++;
                    if (matchPos == searchPattern.Count)
                    {
                        foreach (var r in replacementPattern)
                            output.Write(r);
                        matchPos = 0;
                    }
                }
            }
        }
    }
