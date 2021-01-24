        [HttpPost]
        public void Post(IFormFile file)
        {
            _fileSystemProvider.SaveToFileSystemAsync(_uploadSettings.GetReplacedDirectoryPath(), file.FileName, file.OpenReadStream());
        }
