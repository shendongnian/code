    static void Main(string[] args)
    {
        var stringBuilder = new StringBuilder();
        using (StreamReader streamReader = File.OpenText("file.txt"))
        {
            string line;
            while (( line=streamReader.ReadLine())!=null)
            {
                stringBuilder.AppendLine(line);
            }
        }
    }
