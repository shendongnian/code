    public void DeleteLinesFromFile(string strLineToDelete)
        {
            string strFilePath = "Provide the path of the text file";
            string strSearchText = strLineToDelete;
            string strOldText;
            string n = "";
            StreamReader sr = File.OpenText(strFilePath);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (!strOldText.Contains(strSearchText))
                {
                    n += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(strFilePath, n);
        }
