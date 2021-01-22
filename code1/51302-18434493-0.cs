        /// <summary>
        /// Extract Embedded resource files to a given path
        /// </summary>
        /// <param name="embeddedFileName">Name of the embedded resource file</param>
        /// <param name="destinationPath">Path and file to export resource to</param>
        public static void extractResource(String embeddedFileName, String destinationPath)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string[] arrResources = currentAssembly.GetManifestResourceNames();
            foreach (string resourceName in arrResources)
                if (resourceName.ToUpper().EndsWith(embeddedFileName.ToUpper()))
                {
                    Stream resourceToSave = currentAssembly.GetManifestResourceStream(resourceName);
                    var output = File.OpenWrite(destinationPath);
                    resourceToSave.CopyTo(output);
                    resourceToSave.Close();
                }
        }
