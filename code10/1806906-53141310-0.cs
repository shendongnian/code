    // Show the launcher page
    public void LoadLauncherPage()
    {
        Uri uri = Control.BuildLocalStreamUri("Launcher", "/index.html");
        Control.NavigateToLocalStreamUri(uri, new StreamResolver(BroadsheetInterface));
    }
    // Resolver for mapping the files
    public class StreamResolver : IUriToStreamResolver
    {
        private BroadsheetInterface_Helper broadsheetInterface;
        public StreamResolver(BroadsheetInterface_Helper broadsheetInterface)
        {
            this.broadsheetInterface = broadsheetInterface;
        }
        public IAsyncOperation<IInputStream> UriToStreamAsync(Uri uri)
        {
            if (uri == null) throw new Exception();
            return GetContent(uri.AbsolutePath).AsAsyncOperation();
        }
        private async Task<IInputStream> GetContent(string path)
        {
            try
            {
                string fullname = broadsheetInterface.AccountHelper.CurrentAccount.RootFolder.FullName + path.Replace("/", "\\");
                StorageFile f = await StorageFile.GetFileFromPathAsync(fullname);
                IRandomAccessStream stream = await f.OpenAsync(FileAccessMode.Read);
                return stream;
            }
            catch (Exception) { throw new Exception("Invalid path"); }
        }
    }
