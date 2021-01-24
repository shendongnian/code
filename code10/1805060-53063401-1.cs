    class WorkController
    {
        private DataSourceExportConfig _dataSourceExportConfig;
        private SourceFileService _sourceFileService;
        private string destinationBase;
        public async Task CopyPendingFilesAsync(SourcePath sourcePath, Options options)
        {
            await Task.WhenAll(Enumerable.Range(0, 10).Select(x => Worker(sourcePath, options)));
        }
        public async Task Worker(SourcePath sourcePath, Options options)
        {
            SourceFile file = null;
            while (_sourceFileService.GetNextFile(out file))
            {
                ProcessFile(file, destinationBase, options);
            }
        }
        private void ProcessFile(SourceFile file, string destinationBase, Options options)
        {
        }
    }
