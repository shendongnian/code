        /// <summary>
        /// Check if this is the first time ADDapt has ever executed
        /// </summary>
        /// <remarks>
        /// We know that ADDapt has run before with the existence of FirstTime.txt.
        /// </remarks>
        /// <returns>
        /// False - this was the first time the application executed
        /// </returns>
        /// <param name="ADDaptBinDirectory">
        /// Application base directory
        /// </param>
        public bool CheckFirstTime(String ADDaptBinDirectory)
        {
            bool bADDaptRunFirstTime = false;
            String FirstTimeFileName = string.Format("{0}//FirstTime.txt", ADDaptBinDirectory);
            // Find FirstTime.txt in Bin Directory
            if (File.Exists(FirstTimeFileName))
                bADDaptRunFirstTime = true;
            else
            {
                // Create FirstTime file
            }
            
            return bADDaptRunFirstTime;
        }
        /// <summary>
        /// Create the FirstTime file
        /// </summary>
        /// <remarks>
        /// Saving the creation date in the first time documents when the app was initially executed
        /// </remarks>
        /// <param name="FirstTimeFN">
        /// Full windows file name (Directory and all)
        /// </param>
        private void CreateFirstTimeFile(String FirstTimeFN)
        {
            FileInfo fi = new FileInfo(FirstTimeFN);
            DateTime dt = DateTime.Now;
            using (TextWriter w = fi.CreateText())
            {
                w.WriteLine(string.Format("Creation Date: {0:g} ", dt));
            }
        }
