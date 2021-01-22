        // Extracts the contents of the embedded file, writes them to a temp file, executes it, and cleans up automatically on exit.
        private void ExtractAndRunMyScript()
        {
            string vbsFilePath;
            // By default, TempFileCollection cleans up after itself.
            using (var tempFiles = new System.CodeDom.Compiler.TempFileCollection())
            {
                vbsFilePath= tempFiles.AddExtension("vbs");
                // Using IntelliSense will display the name, but it's the file name
                // minus its extension.
                System.IO.File.WriteAllText(vbsFilePath, global::Instrumentation.Properties.Resources.MyEmbeddedFileNameWithoutExtension);
                RunMyScript(vbsFilePath);
            }
            System.Diagnostics.Debug.Assert(!File.Exists(vbsFilePath), @"Temp file """ + vbsFilePath+ @""" has not been deleted.");
        }
