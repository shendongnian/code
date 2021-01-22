lang-cs
public async Task<string> CreateZipFile(string sourceDirectoryPath, string name)
{
    var path = HostingEnvironment.MapPath(TempPath) + name;
    await Task.Run(() =>
    {
        if (File.Exists(path)) File.Delete(path);
        ZipFile.CreateFromDirectory(sourceDirectoryPath, path);
    });
    return path;
}
and then you can unzip zip file with this methods:
1- This method work with zip file path
lang-cs
public async Task ExtractZipFile(string filePath, string destinationDirectoryName)
{
    await Task.Run(() =>
    {
        var archive = ZipFile.Open(filePath, ZipArchiveMode.Read);
        foreach (var entry in archive.Entries)
        {
            entry.ExtractToFile(Path.Combine(destinationDirectoryName, entry.FullName), true);
        }
        archive.Dispose();
    });
}
2- This method work with zip file stream
lang-cs
public async Task ExtractZipFile(Stream zipFile, string destinationDirectoryName)
{
    string filePath = HostingEnvironment.MapPath(TempPath) + Utility.GetRandomNumber(1, int.MaxValue);
    using (FileStream output = new FileStream(filePath, FileMode.Create))
    {
        await zipFile.CopyToAsync(output);
    }
    await Task.Run(() => ZipFile.ExtractToDirectory(filePath, destinationDirectoryName));
    await Task.Run(() => File.Delete(filePath));
}
