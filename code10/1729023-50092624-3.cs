            using System.IO;
            //Save the original content to restore it when required
            private string SavedState = String.Empty;
    
            private void PriyaMethod(string FilePath, bool IsDebug, string ReplaceWord, params string[] WordsToReplace)
            {
                //string[] WordsToUse = { "INFO", "ERROR", "FATAL", "DEBUG", "WARN" };
    
                if (System.IO.File.Exists(FilePath))
                {
                    // string[] Lines = System.IO.File.ReadAllLines(FilePath);
                    // string[] Words = System.IO.File.ReadAllText(FilePath).Split(' 
                     string Text = System.IO.File.ReadAllText(FilePath);
                    // byte[] Bytes = System.IO.File.ReadAllBytes(FilePath);
                    // IEnumerable<string> ReadLines = System.IO.File.ReadLines(FilePath);*/
    
                     SavedState = Text;
    
                     if (IsDebug)
                     {
    
                        for (int i = 0; i < WordsToReplace.Length; ++i)
                        {
                            Text = Text.Replace(WordsToReplace[i], ReplaceWord);
                        }
    
                        //If the file is open, it closes it to prevent an IOException from occurring
                        File.Open(FilePath, FileMode.Open, FileAccess.Write, FileShare.Read).Close();
                        File.WriteAllText(FilePath, Text); //Write new content
                     }
                     else
                     {
                        //If the file is open, it closes it to prevent an IOException from occurring
                        File.Open(FilePath, FileMode.Open, FileAccess.Write, FileShare.Read).Close();
                        File.WriteAllText(FilePath, SavedState); //Restore old content
                     }
    
                }
                else
                {
                    throw new FileNotFoundException(System.String.Format("The file {0} does not exists", FilePath));
                }
            }
