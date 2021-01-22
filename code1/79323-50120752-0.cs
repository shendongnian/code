    string GetLine(string fileName, int lineNum)
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            string line;
            int count = 1;
            while ((line = sr.ReadLine()) != null)
            {
                if(count == lineNum)
                {
                    return line;
                }
                count++;
            }
        }
        return "line number is bigger than number of lines";  
    }
