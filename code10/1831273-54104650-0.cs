    var Dizinler = Directory.EnumerateDirectories("C:\")
               .Select(s => new DirectoryInfo(s))
               .Where(s => s.Attributes.HasFlag(FileAttributes.Directory))
               .Where(s => !s.Attributes.HasFlag(FileAttributes.System))
               .Where(s => !s.Attributes.HasFlag(FileAttributes.Hidden))
               .Select(s=> s.FullName).ToArray();
