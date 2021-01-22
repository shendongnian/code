    public class Zip
    {
        private string _filePath;
        public string FilePath { get { return _filePath; } }
        /// <summary>
        /// Zips a set of files
        /// </summary>
        /// <param name="filesToZip">A list of filepaths</param>
        /// <param name="sZipFileName">The file name of the new zip (do not include the file extension, nor the full path - just the name)</param>
        /// <param name="deleteExistingZip">Whether you want to delete the existing zip file</param>
        /// <remarks>
        /// Limitation - all files must be in the same location. 
        /// Limitation - must have read/write/edit access to folder where first file is located.
        /// Will throw exception if the zip file already exists and you do not specify deleteExistingZip
        /// </remarks>
        public Zip(List<string> filesToZip, string sZipFileName, bool deleteExistingZip = true)
        {
            if (filesToZip.Count > 0)
            {
                if (File.Exists(filesToZip[0]))
                {
                    // Get the first file in the list so we can get the root directory
                    string strRootDirectory = Path.GetDirectoryName(filesToZip[0]);
                    // Set up a temporary directory to save the files to (that we will eventually zip up)
                    DirectoryInfo dirTemp = Directory.CreateDirectory(strRootDirectory + "/" + DateTime.Now.ToString("yyyyMMddhhmmss"));
                    // Copy all files to the temporary directory
                    foreach (string strFilePath in filesToZip)
                    {
                        if (!File.Exists(strFilePath))
                        {
                            throw new Exception(string.Format("File {0} does not exist", strFilePath));
                        }
                        string strDestinationFilePath = Path.Combine(dirTemp.FullName, Path.GetFileName(strFilePath));
                        File.Copy(strFilePath, strDestinationFilePath);
                    }
                    // Create the zip file using the temporary directory
                    if (!sZipFileName.EndsWith(".zip")) { sZipFileName += ".zip"; }
                    string strZipPath = Path.Combine(strRootDirectory, sZipFileName);
                    if (deleteExistingZip == true && File.Exists(strZipPath)) { File.Delete(strZipPath); }
                    ZipFile.CreateFromDirectory(dirTemp.FullName, strZipPath, CompressionLevel.Fastest, false);
                    // Delete the temporary directory
                    dirTemp.Delete(true);
                    _filePath = strZipPath;                    
                }
                else
                {
                    throw new Exception(string.Format("File {0} does not exist", filesToZip[0]));
                }
            }
            else
            {
                throw new Exception("You must specify at least one file to zip.");
            }
        }
    }
