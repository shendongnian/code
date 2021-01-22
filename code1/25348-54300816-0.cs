c#
public static class Glob
{
  public static IEnumerable<FileInfo> Exec(DirectoryInfo dir, string glob)
  {
    var matcher = DotNet.Globbing.Glob.Parse(glob);
    return dir.EnumerateAllFiles().Where(f => matcher.IsMatch(f.FullName));
  }
  public static IEnumerable<FileInfo> EnumerateAllFiles(this DirectoryInfo dir)
  {
    foreach (var f in dir.EnumerateFiles())
    {
      yield return f;
    }
    foreach (var sub in dir.EnumerateDirectories())
    {
      foreach (var f in EnumerateAllFiles(sub))
      {
        yield return f;
      }
    }
  }
}
