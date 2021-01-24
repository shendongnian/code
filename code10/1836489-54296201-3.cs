cs
private static bool IsVhd(string path)
{
    byte[] vhdHeader = { 0x63, 0x6F, 0x6E, 0x65, 0x63, 0x74, 0x69, 0x78 };
    byte[] header;
    FileInfo file = new FileInfo(path);
    long length = file.Length;
    using (BinaryReader br = new BinaryReader(file.OpenRead()))
    {
        br.BaseStream.Position = length - 0x200; //Where the "conectix" is located at
        header = br.ReadBytes(8);
    }
    return vhdHeader.SequenceEqual(header);
}
I believe this would do.
Edit 4:
cs
private static bool IsVhd(string path)
{
    Span<byte> vhdHeader = stackalloc byte[] { 0x63, 0x6F, 0x6E, 0x65, 0x63, 0x74, 0x69, 0x78 };
    Span<byte> header = stackalloc byte[8];
    FileInfo file = new FileInfo(path);
    long length = file.Length;
    using (BinaryReader br = new BinaryReader(file.OpenRead()))
    {
        br.BaseStream.Position = length - 0x200; //Where the "conectix" is located at
        br.Read(header);
    }
    return vhdHeader.SequenceEqual(header);
}
<s>Non</s>Less-allocating version, in case you're using .NET Core. (Requires C# 7.3)
Edit 5:
cs
private static bool IsVhd(string path)
{
    Span<byte> vhdHeader = stackalloc byte[] { 0x63, 0x6F, 0x6E, 0x65, 0x63, 0x74, 0x69, 0x78 };
    Span<byte> header = stackalloc byte[8];
    FileInfo file = new FileInfo(path);
    long length = file.Length;
    using (BinaryReader br = new BinaryReader(file.OpenRead()))
    {
        br.BaseStream.Position = length - 0x200; //Where the "conectix" is located at
        for (int i = 0; i < 8; i++)
            header[i] = br.ReadByte();
    }
    return vhdHeader.SequenceEqual(header);
}
Same, but for .NET Frameworks (Requires Version 4.6.1 or higher - Ideally 4.7.1 due to optimisation; Also requires `System.Memory` NuGet package. C# 7.3)
