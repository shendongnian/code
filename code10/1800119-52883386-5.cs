    static void PatchStream(Stream source, Stream target
        , IList<byte> searchPattern, IList<byte> replacementPattern)
    {
        using (var input = new BinaryReader(source))
        using (var output = new BinaryWriter(target))
        {
            var buffer = new Queue<byte>();
            while (true)
            {
                if (buffer.Count < searchPattern.Count)
                {
                    if (input.BaseStream.Position < input.BaseStream.Length)
                        buffer.Enqueue(input.ReadByte());
                    else
                        break;
                }
                else if (buffer.Zip(searchPattern, (b, s) => b == s).All(c => c))
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
            foreach (var b in buffer)
                output.Write(b);
        }
    }
