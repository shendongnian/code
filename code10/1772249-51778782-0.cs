    bool IsContain(string word, string filePath)
    {
            if(File.Exists(filePath))
            {
                using(var sr = File.OpenText(filePath))
                {
                    string w = string.Empty;
                    while((w = sr.ReadLine()) != null)
                    {
                        if(w == word)
                            return true;
                    }
                }
            }
            return false;
        }
