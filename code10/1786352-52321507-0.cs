        private StringBuilder Contents = new StringBuilder();
        private void ExploreAPath(string Path)
        {
            Contents.Append("Contnet of DIR "+ Path + " : \r\n");
 
            string[] Files = System.IO.Directory.GetFiles(Path);
            for (int i = 0; i < Files.Length; i++)
            {
                Contents.Append("\t" + Files[i]+"\r\n");
            }
            string[] Directories = System.IO.Directory.GetDirectories(Path);
            for (int i = 0; i < Directories.Length; i++)
            {
                ExploreAPath(Directories[i]);
            }
        }
