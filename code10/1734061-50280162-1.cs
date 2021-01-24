    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            SubSubFolders(@"C:\Program Files\Microsoft Office", list);
            Console.WriteLine(list.Aggregate((s1,s2)=>s1+Environment.NewLine+s2));
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
        public static void SubSubFolders(string basePath, List<string> folders)
        {
            //if (folders.Count > 500) return;
            string[] dirs = new string[] { };
            try
            {
                dirs = Directory.GetDirectories(basePath);
            }
            catch(Exception exc)
            {
                // Handle access failures - there will be folders you can't enumerate unless running as admin
            }
            for (int i = 0; i < dirs.Length; i++)
            {
                folders.Add(dirs[i]);
                SubSubFolders(dirs[i], folders);
            }
        }
    }
