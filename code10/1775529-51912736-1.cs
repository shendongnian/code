        static public IEnumerable<string> ModFileDupilcate(string[] SimsModDownloadDirectory, 
           string[] SimsModsDirectory)
        {
            var result = SimsModDownloadDirectory.Select((x, i) => 
                SimsModsDirectory.Contains(x) ? x : string.Empty).
                Where(x => !string.IsNullOrEmpty(x));
            return result;
        }
