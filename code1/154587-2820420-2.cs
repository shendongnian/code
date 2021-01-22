        public string GetResourceTextFile(string filename)
        {
            string result = string.Empty;
            using (Stream stream = this.GetType().Assembly.
                       GetManifestResourceStream("assembly.folder."+filename))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }
