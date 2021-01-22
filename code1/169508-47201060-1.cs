    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    
    public static class FTP
    {
        public static long GetFtpDirectorySize(Uri requestUri, NetworkCredential networkCredential, bool recursive = true)
        {
            //Get files/directories contained in CURRENT directory.
            var directoryContents = GetFtpDirectoryContents(requestUri, networkCredential);
    
            long ftpDirectorySize = default(long); //Set initial value of the size to default: 0
            var subDirectoriesList = new List<Uri>(); //Create empty list to fill it later with new founded directories.
    
            //Loop on every file/directory founded in CURRENT directory. 
            foreach (var item in directoryContents)
            {
                //Combine item path with CURRENT directory path.
                var itemUri = new Uri(Path.Combine(requestUri.AbsoluteUri + "\\", item));
                var fileSize = GetFtpFileSize(itemUri, networkCredential); //Get item file size.
    
                if (fileSize == default(long)) //This means it has no size so it's a directory and NOT a file.
                    subDirectoriesList.Add(itemUri); //Add this item Uri to subDirectories to get it's size later.
                else //This means it has size so it's a file.
                    Interlocked.Add(ref ftpDirectorySize, fileSize); //Add file size to overall directory size.
            }
    
            if (recursive) //If recursive true: it'll get size of subDirectories files.
                Parallel.ForEach(subDirectoriesList, (subDirectory) => //Loop on every directory
                //Get size of selected directory and add it to overall directory size.
            Interlocked.Add(ref ftpDirectorySize, GetFtpDirectorySize(subDirectory, networkCredential, recursive)));
    
            return ftpDirectorySize; //returns overall directory size.
        }
        public static long GetFtpDirectorySize(string requestUriString, string userName, string password, bool recursive = true)
        {
            //Initialize Uri/NetworkCredential objects and call the other method to centralize the code
            return GetFtpDirectorySize(new Uri(requestUriString), GetNetworkCredential(userName, password), recursive);
        }
    
        public static long GetFtpFileSize(Uri requestUri, NetworkCredential networkCredential)
        {
            //Create ftpWebRequest object with given options to get the File Size. 
            var ftpWebRequest = GetFtpWebRequest(requestUri, networkCredential, WebRequestMethods.Ftp.GetFileSize);
    
            try { return ((FtpWebResponse)ftpWebRequest.GetResponse()).ContentLength; } //Incase of success it'll return the File Size.
            catch (Exception) { return default(long); } //Incase of fail it'll return default value to check it later.
        }
        public static List<string> GetFtpDirectoryContents(Uri requestUri, NetworkCredential networkCredential)
        {
            var directoryContents = new List<string>(); //Create empty list to fill it later.
                                                        //Create ftpWebRequest object with given options to get the Directory Contents. 
            var ftpWebRequest = GetFtpWebRequest(requestUri, networkCredential, WebRequestMethods.Ftp.ListDirectory);
            try
            {
                using (var ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse()) //Excute the ftpWebRequest and Get It's Response.
                using (var streamReader = new StreamReader(ftpWebResponse.GetResponseStream())) //Get list of the Directory Contentss as Stream.
                {
                    var line = string.Empty; //Initial default value for line.
                    do
                    {
                        line = streamReader.ReadLine(); //Read current line of Stream.
                        directoryContents.Add(line); //Add current line to Directory Contentss List.
                    } while (!string.IsNullOrEmpty(line)); //Keep reading while the line has value.
                }
            }
            catch (Exception) { } //Do nothing incase of Exception occurred.
            return directoryContents; //Return all list of Directory Contentss: Files/Sub Directories.
        }
        public static FtpWebRequest GetFtpWebRequest(Uri requestUri, NetworkCredential networkCredential, string method = null)
        {
            var ftpWebRequest = (FtpWebRequest)WebRequest.Create(requestUri); //Create FtpWebRequest with given Request Uri.
            ftpWebRequest.Credentials = networkCredential; //Set the Credentials of current FtpWebRequest.
    
            if (!string.IsNullOrEmpty(method))
                ftpWebRequest.Method = method; //Set the Method of FtpWebRequest incase it has a value.
            return ftpWebRequest; //Return the configured FtpWebRequest.
        }
        public static NetworkCredential GetNetworkCredential(string userName, string password)
        {
            //Create and Return NetworkCredential object with given UserName and Password.
            return new NetworkCredential(userName, password);
        }
    }
