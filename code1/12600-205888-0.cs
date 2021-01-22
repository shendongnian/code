        public FileStream OpenFile(string path)
        {
            FileStream f = null;
            try
            {
                f = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (FileNotFoundException)
            {
            }
            return f;
        }
