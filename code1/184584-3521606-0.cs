        private static string MessageText()
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (assembly != null)
            {
                var stream = assembly.GetManifestResourceStream("RootProjectNamespace.LoremIpsum.txt");
                if (stream != null)
                {
                    var textStreamReader = new StreamReader(stream);
                    return textStreamReader.ReadToEnd();
                }
            }
            return "";
        }
