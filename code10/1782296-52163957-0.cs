        public class SimpleLogger
        {
            private static SimpleLogger logger;
            private string path = null;
            protected SimpleLogger(string path)
            {
                this.path = path;
            }
            public static SimpleLogger Instance(string path)
            {
                if (logger == null)
                {
                    logger = new SimpleLogger(path);
                }
                return logger;
            }
            public void Info(string info)
            {
                string path = $"{logger.path}{DateTime.Now.ToShortDateString()}_Info.txt";
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine($"{DateTime.Now} - {info}");
                }
            }
        }
