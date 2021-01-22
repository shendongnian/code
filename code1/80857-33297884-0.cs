    public static void EmptyDirectory(string directory)
    {
        // First delete all the files, making sure they are not readonly
        var stackA = new Stack<DirectoryInfo>();
        stackA.Push(new DirectoryInfo(directory));
     
        var stackB = new Stack<DirectoryInfo>();
        while (stackA.Any())
        {
            var dir = stackA.Pop();
            foreach (var file in dir.GetFiles())
            {
                file.IsReadOnly = false;
                file.Delete();
            }
            foreach (var subDir in dir.GetDirectories())
            {
                stackA.Push(subDir);
                stackB.Push(subDir);
            }
        }
        
        // Then delete the sub directories depth first
        while (stackB.Any())
        {
            stackB.Pop().Delete();
        }
    }
