        public String DoTest()
        {
            string fileContent = "";
            IEnumerable<string> filesNames = System.IO.Directory.GetFiles(logDir).Where(x => x.ToLower().Contains("aud"));
            foreach (var fileName in filesNames)
            {
                fileContent = string.Join("", System.IO.File.ReadAllText(fileName));
            }
            return fileContent;
        }
