    static string readFromTextFile(string path)
    {
        StreamReader sr = new StreamReader(path);
        StringBuilder sb = new StringBuilder();
        //Read the first line of text
        string line = sr.ReadLine();
        //Continue to read until you reach end of file
        while (line != null)
        {
            //write the line to console window
            Console.WriteLine(line);
            //Read the next line
            line = sr.ReadLine();
            sb.AppendLine(line);
        }
        //close the file
        sr.Close();
        return sb.ToString();
    }
