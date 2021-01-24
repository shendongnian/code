     public static class LoggerExtensions
        {
            public static void Warn(this ILoggerFacade loger, string message)
            {
                using (StreamWriter s = File.AppendText("Log.txt"))
                {
                    s.WriteLine(string.Format(" {0}-{1}: {2}", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.ffff"), Category.Warn, message));
                    s.Close();
                }
            }
        }
