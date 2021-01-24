        public void Copy(string Source, string Destination)
        {
            string[] SourceFiles = System.IO.Directory.GetFiles(Source);
            for (int i = 0; i < SourceFiles.Length; i++)
            {
                string DestinationFilePath = System.IO.Path.Combine(Destination, System.IO.Path.GetFileName(SourceFiles[i]));
                if (System.IO.File.Exists(DestinationFilePath))
                {
                    var DialogResult = MessageBox.Show($"File `{System.IO.Path.GetFileName(SourceFiles[i])}` Exists in the Destination. Are you want to overwrite this file ?", "File Exist !", MessageBoxButtons.YesNo);
                    if (DialogResult == DialogResult.Yes)
                        System.IO.File.Copy(SourceFiles[i], DestinationFilePath, true);
                }
                else
                {
                    System.IO.File.Copy(SourceFiles[i], DestinationFilePath);
                }
            }
        }
