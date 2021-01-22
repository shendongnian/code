        /// <summary>
        /// This function opens a delimited file and cleans up any string quantifiers
        /// </summary>
        /// <param name="FileFullPath">Full path of the delimited string</param>
        /// <param name="CurrentDelimiter">What string / character the file uses as the delimiter</param>
        /// <param name="NewDelimiter">What new delimiter string to use</param>
        /// <returns>Returns String representation of the new delimited file</returns>
        private static String CleanDelimitedFile(String FileFullPath, String[] CurrentDelimiter, String NewDelimiter) {
            //-- if the file exists stream it to host
            if (System.IO.File.Exists( FileFullPath )) {
                Microsoft.VisualBasic.FileIO.TextFieldParser cvsParser = null;
                System.Text.StringBuilder parseResults = new System.Text.StringBuilder();
                try {
                    // new parser
                    cvsParser = new Microsoft.VisualBasic.FileIO.TextFieldParser(FileFullPath);
                    // delimited file has certain fields enclosed in quotes
                    cvsParser.HasFieldsEnclosedInQuotes = true;
                    // the current delimiter
                    cvsParser.Delimiters = CurrentDelimiter;
                    // iterate through all the lines of the file
                    Boolean FirstLine = true;
                    while (!cvsParser.EndOfData ) {
                        if (FirstLine) {
                            FirstLine = false;
                        }
                        else {
                          parseResults.Append("\n");  
                        }
                        Boolean FirstField = true;
                        // iterate through each field
                        foreach (String item in cvsParser.ReadFields()) {
                            if (FirstField) {
                                parseResults.Append(item);
                                FirstField = false;
                            } 
                            else {
                                parseResults.Append(NewDelimiter + item);
                            }
                        }
                        
                    }
                    return parseResults.ToString();
                }
                finally {
                    if (cvsParser != null) {
                        cvsParser.Close();
                        cvsParser.Dispose();
                    }
                }
            }
            return String.Empty;
        }
