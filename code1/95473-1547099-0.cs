        public List<Object> GetFilesAndDirectories(string path)
        {
            List<Object> lst = new List<Object>();
            try
            {
                foreach (string d in Directory.GetDirectories(path))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        lst.Add(f);
                    }
                    lst.Add(d);
                    lst.AddRange(GetFilesAndDirectories(d));
                }
            }
            catch {} //dont stop
            return lst;
        }
        List<Object> stuff = GetFilesAndDirectories(someRoot);
