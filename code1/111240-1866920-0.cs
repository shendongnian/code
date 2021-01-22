    string line = "";
    StreamReader data = new StreamReader("your file.txt");
    List<Chapter> chapters = new List<Chapter>();
    while ((line = data.ReadLine()) != null)
    {
        if (line.StartsWith("Chapter"))
        {
            chapters.Add(new Chapter(line));
        }
        else if (line.StartsWith("Article"))
        {
            chapters.Last().Articles.Add(new Article(line));
        }
    }
