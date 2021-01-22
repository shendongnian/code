    public string GetResourceFileText(string filename, string assemblyName)
        {
            string result = string.Empty;
            using (Stream stream = 
                System.Reflection.Assembly.Load(assemblyName).GetManifestResourceStream($"{assemblyName}.{filename}"))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }
