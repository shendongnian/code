    static void WriteDirectories(string path)
    {
        string[] dirs = Directory.GetDirectories(path);
        var allDirs = new List<string>();
        Stack<string> stack = new Stack<string>(dirs);
        while (stack.Any())
        {
            var dir = stack.Pop();
            allDirs.Add(dir);
            foreach (var tmp in Directory.GetDirectories(dir))
            {
                stack.Push(tmp);
            }
        }
        // Do something with allDirs
    }
