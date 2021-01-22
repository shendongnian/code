        private static IDictionary<string, long> folderSizes;
        public static long GetDirectorySize(string dirName)
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
            folderSizes[dirName] = b;
            return b;
        }
        static void Main(string[] args)
        {
            folderSizes = new Dictionary<string, long>();
            foreach (string key in folderSizes.Keys)
            {
                Console.WriteLine("dirName = " + key + " dirSize = " + folderSizes[key]);
            }
            // now folderSizes will contain a key for each directory (starting
            // at c:\StartingFolder and including all subdirectories), and
            // the dictionary value will be the folder size
        }
