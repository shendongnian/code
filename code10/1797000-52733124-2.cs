        public void Copy(string Source, string Destination)
        {
            /// Set Session ....
            Session["Destination"] = Destination;
            
            List<string> DuplicatedFiles = new List<string>();
            string[] SourceFiles = System.IO.Directory.GetFiles(Source);
            for (int i = 0; i < SourceFiles.Length; i++)
            {
                string DestinationFilePath = System.IO.Path.Combine(Destination, System.IO.Path.GetFileName(SourceFiles[i]));
                if (System.IO.File.Exists(DestinationFilePath))
                {
                   // Add into Duplication List
                   DuplicatedFiles.Add(SourceFiles[i]);
                }
                else
                {
                    System.IO.File.Copy(SourceFiles[i], DestinationFilePath);
                }
            }
            /// Set Session .....
            Session["DouplicatedFiles"] = DuplicatedFiles;
        }
