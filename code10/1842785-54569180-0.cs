`
static void Main(string[] args)
{
    var file = CreateFile("Mary had a little lamb, its fleece was white as snow...");
    var contentFromFile = ReadFile(file);
    Console.WriteLine(contentFromFile);
}
private static MemoryMappedFile CreateFile(string content)
{
    var file = MemoryMappedFile.CreateNew("temp.csv", 1048576);
    using (var stream = file.CreateViewStream())
    {
        using (var writer = new StreamWriter(stream))
        {
            writer.WriteLine(content);
        }
    }
    return file;
}
private static string ReadFile(MemoryMappedFile file)
{
    using (var stream = file.CreateViewStream())
    {
        using (var reader = new StreamReader(stream))
        {
            var contentReadFromStream = reader.ReadLine();
            return contentReadFromStream;
        }
    }
}
`
  [1]: https://docs.microsoft.com/en-us/dotnet/standard/io/memory-mapped-files
