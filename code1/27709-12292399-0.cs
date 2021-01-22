        /// <summary>
        /// Copies the source to the dest.  Creating any neccessary folders in the destination path as neccessary.
        /// 
        /// For example:
        /// Directory Example:
        /// pSource = C:\somedir\conf and pDest=C:\somedir\backups\USER_TIMESTAMP\somedir\conf   
        /// all files\folders under source will be replicated to destination and any paths in between will be created.
        /// </summary>
        /// <param name="pSource">path to file or directory that you want to copy from</param>
        /// <param name="pDest">path to file or directory that you want to copy to</param>
        /// <param name="pOverwriteDest">if true, files/directories in pDest will be overwritten.</param>
        public static void FileCopyWithReplicate(string pSource, string pDest, bool pOverwriteDest)
        {
            string destDirectory = Path.GetDirectoryName(pDest);
            System.IO.Directory.CreateDirectory(destDirectory);
            if (Directory.Exists(pSource))
            {
                DirectoryCopy(pSource, pDest,pOverwriteDest);
            }
            else
            {
                File.Copy(pSource, pDest, pOverwriteDest);
            }
        }
        // From MSDN Aricle "How to: Copy Directories"
        // Link: http://msdn.microsoft.com/en-us/library/bb762914.aspx
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
