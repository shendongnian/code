        private String path;
        public int copyAllContents(String destinationFolder, ProgressBar progressBar)
        {
            int countCopyFiles = 0;
            if (!Directory.Exists(destinationFolder))
            { Directory.CreateDirectory(destinationFolder); }
            String[] allFilesForCurrentFolder = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            String[] subFoldersAllpath = Directory.GetDirectories(path);
            for (int i = 0; i < allFilesForCurrentFolder.Length; i++)
            {
                try { File.Copy(allFilesForCurrentFolder[i], destinationFolder + "\\" + Path.GetFileName(allFilesForCurrentFolder[i])); countCopyFiles++; progressBar.Value++; }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString()); }
            }
            if (subFoldersAllpath.Length == 0)
            { return allFilesForCurrentFolder.Length; };
            for (int i = 0; i < subFoldersAllpath.Length; i++)
            {
                this.path = subFoldersAllpath[i];
                String[] subFoldersAllpathLastFolder = subFoldersAllpath[i].Split('\\');
                countCopyFiles += this.copyAllContents(destinationFolder + "\\" + subFoldersAllpathLastFolder[subFoldersAllpathLastFolder.Length - 1], progressBar);
            }
            return countCopyFiles;
        }
