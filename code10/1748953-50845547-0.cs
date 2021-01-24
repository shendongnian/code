    static void WriteDirectories(string path, int level)
    {
        string[] dirs = Directory.GetDirectories(path/*, "*", SearchOption.AllDirectories*/);
        for (int i = 0; i < dirs.Length; i++)
        {
            int l = level;
            while (l > 0) {
                Console.Write("  ");
                l -= 1;
            }
            Console.Write(dirs[i] + "\n");
            if (Directory.GetDirectories(dirs[i]).Length > 0)
            {
                WriteDirectories(dirs[i], level + 1);continue;
            }
        }
    }
