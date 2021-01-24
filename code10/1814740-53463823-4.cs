    public static void Main(string[] args)
    {
        var info = ProcessDirectory(new DirectoryInfo(@"D:\"));
        using (var fs = new FileStream(@"D:\Reuslts.txt", FileMode.Create))
        {
            using (var sw = new StreamWriter(fs))
            {
                info.Sum();
                info.Order();
                info.WriteResults(sw);
            }
        }
    }
    private static Info ProcessDirectory(DirectoryInfo directoryInfo)
    {
        var baseInfo = new Info(directoryInfo);
        var queue = new Queue<Info>();
        queue.Enqueue(baseInfo);
        while (queue.Count>0) 
        {
            try
            {
                var info = queue.Dequeue();
                foreach (var dir in info.GetDirectories())
                    queue.Enqueue(dir);
            }
            catch (UnauthorizedAccessException e) { }
        }
        return baseInfo;
    }
