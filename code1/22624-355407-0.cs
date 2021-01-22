        /// <summary>
        /// Downloads a file from the given location
        /// </summary>
        /// <param name="url">Location of the file</param>
        /// <param name="dest">The destination of the downloaded file</param>
        /// <returns>False if there was an error, else True</returns>
        public bool DownLoad(string url, string dest)
        {
            WebClient client = new WebClient();
            try
            {
                //Downloads the file from the given url to the given destination				
                client.DownloadFile(url, dest);
                return true;
            }
            catch (WebException)
            {
                // Handle exception
                return false;
            }
            catch (System.Security.SecurityException)
            {
                // Handle exception
                return false;
            }
            catch (Exception)
            {
                // Handle exception
                return false;
            }
        }
