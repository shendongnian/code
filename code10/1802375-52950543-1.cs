    public class DirectoryAnalyser
    {
        private List<string> _files;
        private int _directoryCounter;
        public async Task<List<string>> GetFilesAsync(string directory, CancellationTokenSource cancellationToken, IProgress<DirectoryAnalyserProgress> progress)
        {
            this._files = new List<string>();
            this._directoryCounter = 0;
            await this.GetFilesInternalAsync(directory, cancellationToken, progress);
            return this._files;
        }
        private async Task GetFilesInternalAsync(string directory, CancellationTokenSource cancellationToken, IProgress<DirectoryAnalyserProgress> progress)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            if (!this.CanRead(directory))
            {
                return;
            }
            this._files.AddRange(Directory.GetFiles(directory));
            this._directoryCounter++;
            progress?.Report(new DirectoryAnalyserProgress()
            {
                DirectoriesSearched = this._directoryCounter,
                FilesFound = this._files.Count
            });
            foreach (var subDirectory in Directory.GetDirectories(directory))
            {
                await this.GetFilesInternalAsync(subDirectory, cancellationToken, progress);
            }
        }
        public bool CanRead(string path)
        {
            var readAllow = false;
            var readDeny = false;
            var accessControlList = Directory.GetAccessControl(path);
            if (accessControlList == null)
            {
                return false;
            }
            var accessRules = accessControlList.GetAccessRules(true, true, typeof(SecurityIdentifier));
            if (accessRules == null)
            {
                return false;
            }
            foreach (FileSystemAccessRule rule in accessRules)
            {
                if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read)
                {
                    continue;
                }
                if (rule.AccessControlType == AccessControlType.Allow)
                {
                    readAllow = true;
                }
                else if (rule.AccessControlType == AccessControlType.Deny)
                {
                    readDeny = true;
                }
            }
            return readAllow && !readDeny;
        }
    }
    public class DirectoryAnalyserProgress
    {
        public int FilesFound { get; set; }
        public int DirectoriesSearched { get; set; }
    }
