    static void PatchFile(FileInfo source, FileInfo target
        , IList<byte> searchPattern, IList<byte> replacementPattern)
    {
        using (var input = new BinaryReader(source.OpenRead()))
        using (var output = new BinaryWriter(target.OpenWrite()))
        {
            var buffer = new Queue<byte>();
            var scanning = true;
            while (scanning)
            {
                while (scanning
                    && buffer.Count < searchPattern.Count)
                {
                    if (input.BaseStream.Position < input.BaseStream.Length)
                        buffer.Enqueue(input.ReadByte());
                    else
                        scanning = false;
                }
                if (scanning)
                {
                    if (buffer.Zip(searchPattern, (b, s) => b == s).All(c => c))
                    {
                        foreach (var b in replacementPattern)
                            output.Write(b);
                        buffer.Clear();
                    }
                    else
                    {
                        output.Write(buffer.Dequeue());
                    }
                }
            }
            foreach (var b in buffer)
                output.Write(b);
        }
    }
