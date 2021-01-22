    public static string ExtractResourceAsString(String embeddedFileName)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var arrResources = currentAssembly.GetManifestResourceNames();
            foreach (var resourceName in arrResources)
            {
                if (resourceName.ToUpper().EndsWith(embeddedFileName.ToUpper()))
                {
                    using (var resourceToSave = currentAssembly.GetManifestResourceStream(resourceName))
                    {
                        using (var output = new MemoryStream())
                        {
                            resourceToSave.CopyTo(output);
                            return Encoding.ASCII.GetString(output.ToArray());
                        }
                    }
                }
            }
            return string.Empty;
        }
