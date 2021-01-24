    class FileWriter
    {
        private int index;
        private string fileName = "file.txt";
        private readonly object obj = new object();
        private string FileName { get { lock (obj) { return fileName + index; } } }
        public void Write(string content)
        {
            lock (obj)
            {
                int deleteIndex = index;
                new Thread(() => DeleteOldFile(deleteIndex)).Start();
                index++;
                new Thread(() => File.WriteAllText(fileName + index, content)).Start();
            }
        }
        public string GetFileContent()
        {
            lock (obj)
            {
                return File.ReadAllText(FileName);
            }
        }
        private void DeleteOldFile(int fileNumber)
        {
            var fileToBeDeleted = fileName + fileNumber;
            if (File.Exists(fileToBeDeleted))
                File.Delete(fileToBeDeleted);
        }
    }
