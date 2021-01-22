        Regex NumberExtractor = new Regex("[0-9]{7,16}",RegexOptions.Compiled);
        /// <summary>
        /// Extracts numbers between seven and sixteen digits long from the target file.
        /// Example number to be extracted: +923466666666
        /// </summary>
        /// <param name="TargetFilePath"></param>
        /// <returns>List of the matching numbers</returns>
        private IEnumerable<ulong> ExtractLongNumbersFromFile(string TargetFilePath)
        {
            if (String.IsNullOrEmpty(TargetFilePath))
                throw new ArgumentException("TargetFilePath is null or empty.", "TargetFilePath");
            if (File.Exists(TargetFilePath) == false) 
                throw new Exception("Target file does not exist!");
            FileStream TargetFileStream = null;
            StreamReader TargetFileStreamReader = null; 
            string FileContents = "";
            List<ulong> ReturnList = new List<ulong>();
            try
            {
                TargetFileStream = new FileStream(TargetFilePath, FileMode.Open);
                TargetFileStreamReader = new StreamReader(TargetFileStream);
                FileContents = TargetFileStreamReader.ReadToEnd();
                MatchCollection Matches = NumberExtractor.Matches(FileContents);
                foreach (Match CurrentMatch in Matches) {
                    ReturnList.Add(System.Convert.ToUInt64(CurrentMatch.Value));
                }
            }
            catch (Exception ex)
            {
                //Your logging, etc...
            }
            finally
            {
                if (TargetFileStream != null) {
                    TargetFileStream.Close();
                    TargetFileStream.Dispose();
                }
                if (TargetFileStreamReader != null)
                {
                    TargetFileStreamReader.Dispose();
                }
            }
            return (IEnumerable<ulong>)ReturnList;
        }
