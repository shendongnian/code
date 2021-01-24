    public struct testType
    {
        public string title
        public string name
    }
    
    public List<testType> testlist = new List<testType>();
    
    private void readData(string titlesLine, string namesLine)  
    {
        string[] titles = titlesLine.Split(new string[] { "\",\"" }, StringSplitOptions.None);
        string[] names = namesLine.Split(new string[] { "\",\"" }, StringSplitOptions.None);
        
        for (int i = 0; i < titles.Length; i++)
        {
            testType temp = new testType();
            temp.title = titles[i];
            temp.name = names[i];
            testlist.Add(temp);
        }
    }
