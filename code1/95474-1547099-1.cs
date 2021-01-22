        public List<Object> GetFilesAndDirectories(string path)
        {
            List<Object> lst = new List<Object>();
            string[] dirs = null;
            try
            {
                dirs = Directory.GetDirectories(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (string d in dirs)
            {
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(d);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                foreach (string f in files)
                {
                    lst.Add(f);
                }
                lst.Add(d);
                lst.AddRange(GetFilesAndDirectories(d));
            }
            return lst;
        }
    List<Object> stuff = GetFilesAndDirectories(someRoot);
