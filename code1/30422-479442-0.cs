    /// <summary>
    /// Gets the base score of a computer running Windows Vista or higher.
    /// </summary>
    /// <returns>The String Representation of Score, or False.</returns>
    /// <remarks></remarks>
    public string GetBaseScore()
    {
        // Check if the computer has a \WinSAT dir.
        if (System.IO.Directory.Exists("C:\\Windows\\Performance\\WinSAT\\DataStore"))
        { 
            // Our method to get the most recently updated score.
            // Because the program makes a new XML file on every update of the score,
            // we need to calculate the most recent, just incase the owner has upgraded.
            System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo("C:\\Windows\\Performance\\WinSAT\\DataStore");
            System.IO.FileInfo[] fileDir = null;
            System.IO.FileInfo fileMostRecent = default(IO.FileInfo);
            System.DateTime LastAccessTime = default(System.DateTime);
            string LastAccessPath = string.Empty;
            fileDir = Dir.GetFiles;
            
            // Loop through the files in the \WinSAT dir to find the newest one.
            foreach (var fileMostRecent in fileDir)
            {
                if (fileMostRecent.LastAccessTime >= LastAccessTime)
                {
                    LastAccessTime = fileMostRecent.LastAccessTime;
                    LastAccessPath = fileMostRecent.FullName;
                }
            }
            
            // Create an XmlTextReader instance.
            System.Xml.XmlTextReader xmlReadScore = new System.Xml.XmlTextReader(LastAccessPath);
            
            // Disable whitespace handling so we don't read over them
            xmlReadScore.WhitespaceHandling = System.Xml.WhitespaceHandling.None;
            
            // We need to get to the 25th tag, "WinSPR".
            for (int i = 0; i <= 26; i++)
            {
                xmlReadScore.Read();
            }
            
            // Create a string variable, so we can clean up without any mishaps.
            string SystemScore = xmlReadScore.ReadElementString("SystemScore");
            
            // Clean up.
            xmlReadScore.Close();
            
            return SystemScore;
        }
        
        // Unsuccessful.
        return false;
    }
