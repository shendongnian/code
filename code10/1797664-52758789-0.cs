    class Quest
    {
        public string Answer1;
        public string Answer2;
        public string Answer3;
        public string Answer4;
    }
    
    public static void Main()
    {
        var doc = XDocument.Load("filename.xml");
    
        var rows = doc.Descendants("QuestId").Select(el => new Quest
        {
            Answer1 = el.Element("Answer1").Value,
            Answer2 = el.Element("Answer2").Value,
            Answer3 = el.Element("Answer3").Value,
            Answer4 = el.Element("Answer4").Value,
        });
    
        // iterate over the rows and add to DataTable ...
    
    }
