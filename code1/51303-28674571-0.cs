    public static void extractResource(String embeddedFileName, String destinationPath)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var arrResources = currentAssembly.GetManifestResourceNames();
            foreach (var resourceName in arrResources)
            {
                if (resourceName.ToUpper().EndsWith(embeddedFileName.ToUpper()))
                {
                    using (var resourceToSave = currentAssembly.GetManifestResourceStream(resourceName))
                    {
                        using (var output = File.OpenWrite(destinationPath))
                            resourceToSave.CopyTo(output);
                        resourceToSave.Close();
                    }
                }
            }
        }
