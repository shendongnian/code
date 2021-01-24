        public static byte[] GetResourceData(string resourceName)
        {
            var embeddedResource = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(s => string.Compare(s, resourceName, true) == 0);
            if (!string.IsNullOrWhiteSpace(embeddedResource))
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResource))
                {
                    var data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    return data;
                }
            }
            return null;
        }
