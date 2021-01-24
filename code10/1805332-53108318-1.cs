     private static IEnumerable<LocalFolder> GetFolderFiles(string source)
        {
            var directories = Directory.EnumerateFileSystemEntries(source);
            var folderFiles = directories
                .Where(d => !d.Contains("."))
                 .Select(m =>
                 {
                     var files = Directory.EnumerateFiles(m, "*", SearchOption.AllDirectories)
               .Select(f =>
               {
                   var relative = f.Substring(source.Length + 1);
                   return new LocalFile(relative, () => File.OpenRead(f));
               });
                     return new LocalFolder(m,
                         files);
                 });
            var filesinDir = directories
               .Where(d => d.Contains("."))
                .Select(m =>
                {
                    var files = Directory.EnumerateFiles(source, "*", SearchOption.TopDirectoryOnly)
              .Select(f =>
              {
                  var relative = f.Substring(source.Length + 1);
                  return new LocalFile(relative, () => File.OpenRead(f));
              });
                    return new LocalFolder(m,
                        files);
                });
            return folderFiles.Concat(filesinDir);
        }
