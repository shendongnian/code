    public struct Info
    {
    
        public string Name { get; set; }
        public long Size { get; set; }
        public List<Info> Children { get; set; }
    
        public Info(string name,  IEnumerable<Info> children)
        {
            Name = name;          
            Children = children.ToList();
            Size = Children.Sum(x => x.Size);
        }
        public Info(string name, long size)
        {
            Name = name;
            Size = size;
            Children = null;
        }
        public void RecursiveOrder()
        {
            if (Children == null)return;
            Children = Children.OrderBy(x => x.Children == null).ThenByDescending(x => x.Size).ToList();
            Children.ForEach(c => c.RecursiveOrder());
        }
    
        public void ReurseResults(StreamWriter fs)
        {
            if (Children == null) return;
            fs.WriteLine($"{Name} {Size}");
            foreach (var info in Children)
                info.ReurseResults(fs);
        }
    
        public static Info ProcessDirectory(string dir)
        {
            var info = new Info(dir, ProcessDirectory(new DirectoryInfo(@"D:\")));
            info.RecursiveOrder();
            return info;
        }
    
        private static IEnumerable<Info> ProcessDirectory(DirectoryInfo directoryInfo)
        {
            List<DirectoryInfo> dirs = null;
            List<FileInfo> files = null;
    
            try
            {
                dirs = directoryInfo.EnumerateDirectories().ToList();
                files = directoryInfo.EnumerateFiles().ToList();
            }
            catch (UnauthorizedAccessException e)
            {
                // i'm just ignoring them, do what ever you want here
            }
    
            if (dirs == null || files == null)
                yield break;
    
            foreach (var dir in dirs)
                yield return new Info(dir.FullName, ProcessDirectory(dir));
                    
            foreach (var file in files)
                yield return new Info(file.FullName, file.Length);
                    
        }
    }
