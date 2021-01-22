    string filename = @"c:\yourfilename.txt";
    StringBuilder result = new StringBuilder();
    
                if (System.IO.File.Exists(filename))
                {
                    using (StreamReader streamReader = new StreamReader(filename))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            string newLine = String.Concat("{", line, "}", Environment.NewLine);
                            newLine = newLine.Replace(" ", ", ");
                            result.Append(newLine);
                        }
                    }
                }
    
    using (FileStream fileStream = new FileStream(filename , fileMode, fileAccess))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.Write(result);
                    streamWriter.Close();
                    fileStream.Close();
                }
            
