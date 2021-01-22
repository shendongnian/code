        public long GetDirectorySize(string dirName)
        {
            string[] a = Directory.GetFiles(dirName, "*.*");
    
            long b = 0;
            foreach (string name in a)
            {
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
    
            // recurse on all the directories in current directory
            foreach (string d in Directory.GetDirectories(dirName))
            {
                b += GetDirectorySize(d);
            }
    
            return b;
        }
