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
Same, but for .NET Frameworks (Ideally version 4.7.1 due to optimisation; Also requires `System.Memory` NuGet package. C# 7.3)
Edit 6:
[According to the specs](https://www.microsoft.com/en-us/download/details.aspx?id=23850), it seems that the "hard disk footer" is located at the last 512(511 if created prior MS Virtual PC 2004) bytes. 
Note: Versions previous to Microsoft Virtual PC 2004 create disk images that have a 511-byte disk footer. So the hard disk footer can exist in the last 511 or 512 bytes of the file that holds the hard disk image.
Hard Disk Footer Field Descriptions
The following provides detailed definitions of the hard disk footer fields.
Cookie
Cookies are used to uniquely identify the original creator of the hard disk image. The values are case-sensitive.
Microsoft uses the “conectix” string to identify this file as a hard disk image created by Microsoft Virtual Server, Virtual PC, and predecessor products. The cookie is stored as an eight-character ASCII string with the “c” in the first byte, the “o” in the second byte, and so on.
The previous codes I've written would not work if the file size is less than 512 bytes. I fixed it so it would now deal with files with 511 bytes footer as well. Additionally, I added some comments to help maintaining.
cs
/// <summary>
/// Determines whether the file indicated by the given path is a valid Virtual Hard Disk (.vhd) file.
/// </summary>
/// <param name="path">The path to the .vhd file to check.</param>
/// <returns>Whether the file is a valid vhd file or not.</returns>
//https://www.microsoft.com/en-us/download/details.aspx?id=23850
//See 'Hard Disk Footer Format'
//ASCII string "conectix" (63 6F 6E 65 63 74 69 78) is stored at the last 512 (511 if created on legacy platforms) bytes of the file
private static bool IsVhd(string path)
{
    if (path is null) throw new ArgumentNullException(nameof(path));
    Span<byte> vhdFooterCookie = stackalloc byte[] { 0x63, 0x6F, 0x6E, 0x65, 0x63, 0x74, 0x69, 0x78 };
    Span<byte> cookie = stackalloc byte[9];
    FileInfo file = new FileInfo(path);
    long length = file.Length;
    if (length < 511) return false; //Cannot be smaller than 512 bytes
    using (BinaryReader br = new BinaryReader(file.OpenRead()))
    {
        br.BaseStream.Position = length - 0x200; //Where the footer starts from
#if NETCOREAPP
        br.Read(cookie);
#else
        for (int i = 0; i < 9; i++)
            cookie[i] = br.ReadByte();
#endif
    }
    //SequenceEqual returns false if length is not equal, therefore we slice it to match
    return vhdFooterCookie.SequenceEqual(cookie.Slice(0, 8)) 
           || vhdFooterCookie.SequenceEqual(cookie.Slice(1)); //If created on legacy platform
}
There are some conditional compiling bits, but I believe you could delete unnecessary bits to match your need.
