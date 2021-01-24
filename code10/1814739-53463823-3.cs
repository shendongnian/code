    public class Info
    {
        public Info(DirectoryInfo directoryInfo)
        {
            DirectoryInfo = directoryInfo;
            Name = directoryInfo.FullName;
        }
        public Info(FileInfo fileInfo)
        {
            Name = fileInfo.FullName;
            Size = fileInfo.Length;
        }
        public DirectoryInfo DirectoryInfo { get; }
        public string Name { get; set; }
        public long Size { get; set; }
        public List<Info> Children { get; set; } = new List<Info>();
        public List<Info> GetDirectories()
        {
            if (DirectoryInfo == null) return Children;
            var dirs = DirectoryInfo.EnumerateDirectories()
                                    .Select(x => new Info(x))
                                    .ToList();
            Children = dirs;
            Children.AddRange(DirectoryInfo.EnumerateFiles().Select(x => new Info(x)));
            return dirs;
        }
      
        public void Order()
        {
            if (Children == null) return;
            Children = Children.OrderBy(x => x.Children == null).ThenByDescending(x => x.Size).ToList();
            Children.ForEach(c => c.Order());
        }
        public void Sum() => Size = Children?.Sum(x => x.Size) ?? 0;
        public void WriteResults(StreamWriter fs, int level =0)
        {
            fs.WriteLine($"{new string(' ', level)}{Name} {Size.ToSize(3)}");
            level++;
            if (Children == null) return;
            foreach (var info in Children)
                info.WriteResults(fs, level);
        }
    }
