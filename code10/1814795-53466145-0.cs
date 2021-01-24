    byte[] bytes = File.ReadAllBytes("frame.jpg");
    var output = new List<ushort>();
    for (int i = 0; i < bytes.Length; i += 2)
    {
        try
        {
            output.Add((ushort)((bytes[i] * 256) + bytes[i + 1]));
        }
        catch (IndexOutOfRangeException ex)
        {
            output.Add((ushort)(bytes[i] * 256));
        }
    }
    return output.ToArray();
