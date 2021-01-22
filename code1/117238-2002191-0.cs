    static void Main(string[] args)
    {
        using (StreamReader streamReader = File.OpenText("file.txt"))
        {
            var list = new List<string>();
            string line;
            while (( line=streamReader.ReadLine())!=null)
            {
                list.Add(line);
            }
        }
    }
