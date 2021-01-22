        public static List<string> AllFilesInFolder(string folder)
        {
            var result = new List<string>();
            foreach (string f in Directory.GetFiles(folder))
            {
                result.Add(f);
            }
            foreach (string d in Directory.GetDirectories(folder))
            {
                result.AddRange(AllFilesInFolder(d));
            }
            return result;
        }
