     public static void UpdateTextFile(string fileName, string content, bool doNotOverwrite = true, bool writeNewLine = true)
            {
                StreamWriter file = null;
                try
                {
                    using (file = new System.IO.StreamWriter(@"D:\" + fileName + ".txt", doNotOverwrite))
                    {
                        if (writeNewLine)
                        {
                            file.WriteLine(content);
                        }
                        else file.Write(content);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    //  file.Flush();
                    file.Close();
                }
            }
    Example of calling the method:
        UpdateTextFile("FileName", "file-content", true, false);
