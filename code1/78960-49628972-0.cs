    public static class Extensions
    {
       public static void Run(this string fileName, 
                              string workingDir=null, params string[] arguments)
        {
            using (var p = new Process())
            {
                var args = p.StartInfo;
                args.FileName = fileName;
                if (workingDir!=null) args.WorkingDirectory = workingDir;
                if (arguments != null && arguments.Any())
                    args.Arguments = string.Join(" ", arguments).Trim();
                else if (fileName.ToLowerInvariant() == "explorer")
                    args.Arguments = args.WorkingDirectory;
                p.Start();
            }
        }
    }
