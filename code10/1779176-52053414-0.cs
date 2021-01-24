    public static class Log1
    {
        private static string filePath;
        private static object syncRoot = new object();
        public static void WriteLine(string m)
        {
            lock (syncRoot)
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "test20");
                    Directory.CreateDirectory(filePath);
                    filePath = Path.Combine(filePath, "Print_" + DateTime.Today.ToString("dd-MM-yyyy") + ".txt");
                }
                File.AppendAllText(filePath, m + Environment.NewLine);
            }
        }
    }
