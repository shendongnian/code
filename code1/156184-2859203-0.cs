    class Program
    {
        private static Regex _pattern = new Regex("[~#%&*{}/\\|:<>?\"-]+");
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("C:\\");
            RecursivelyRenameFilesIn(di);
        }
        public static void RecursivelyRenameFilesIn(DirectoryInfo root)
        {
            foreach (FileInfo fi in root.GetFiles())
                if (_pattern.IsMatch(fi.Name))
                    fi.MoveTo(string.Format("{0}\\{1}", fi.Directory.FullName, Regex.Replace(fi.Name, _pattern.ToString(), "_")));
            foreach (DirectoryInfo di in root.GetDirectories())
                RecursivelyRenameFilesIn(di);
        }
    }
