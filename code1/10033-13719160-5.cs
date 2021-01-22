    /// <summary>
        /// Get the file with a specific name and extension
        /// </summary>
        /// <param name="filename">the name of the file to find</param>
        /// <param name="extensionsToCompare">string list of all the extensions</param>
        /// <param name="Location">string of the location</param>
        /// <returns>file with the requested filename</returns>
        public string GetFile( string filename, List<string> extensionsToCompare, string Location)
        {
            foreach (string file in Directory.GetFiles(Location))
            {
                if (extensionsToCompare.Contains(file.Substring(file.IndexOf('.') + 1).ToLower()) &&& file.Substring(Location.Length + 1, (file.IndexOf('.') - (Location.Length + 1))).ToLower() == filename) 
                    return file;
            }
            return "";
        }
