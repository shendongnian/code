        static void Main(string[] args)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(stagepath);
            FileInfo[] file = dirinfo.GetFiles();
            if (file.Length > 0)
            {
                MoveFile(stagepath);
            }
            else
            {
                MonitorDirectory(stagepath);
            }
            Console.ReadKey();
        }
