      public static string GetBasePath
        {
            get
            {
                var basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                basePath = basePath?.Substring(0, basePath.Length - 10);
                return basePath;
            }
        }
