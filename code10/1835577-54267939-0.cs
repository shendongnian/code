C#
private static async Task DownloadToCacheAsync(bool sync)
{
  ...do some analysis to get download locations...
  using (var wc = new WebClient())
  {
    if (sync)
      wc.DownloadFile(new Uri(content.Url), targetPath);
    else
      await wc.DownloadFileTaskAsync(new Uri(content.Url), targetPath);
  }
  ...do other stuff...
}
public static Task DownloadToCacheAsync() => DownloadToTaskAsync(sync: false);
public static void DownloadToCache() => DownloadToTaskAsync(sync: true).GetAwaiter().GetResult();
