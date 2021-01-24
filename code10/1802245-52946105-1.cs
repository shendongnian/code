    public static class Logging
    {
        public static string _DirectoryPath = $"C:\\Users\\{Environment.UserName}\\Desktop\\Logs";
        public static string _FileName = $"{DateTime.Now.ToString("dd.MM.yyyy")}.csv";
        public static void getPath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void logging(string message)
        {
            StreamWriter _sw = new StreamWriter(_DirectoryPath + "\\" + _FileName);
            _sw.Write(message);
            _sw.Flush();
            _sw.Close();
        }
    }
