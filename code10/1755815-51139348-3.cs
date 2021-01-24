    public struct testType
    {
        public string title
        public string name
    }
    
    public List<testType> testlist = new List<testType>();
    
    private void readTitles(string titlesLine)  
    {
        string[] titles = titlesLine.Split(new string[] { "\",\"" }, StringSplitOptions.None);
        
        for (int i = 0; i < titles.Length; i++)
        {
            testType temp = new testType();
            temp.title = titles[i];
            testlist.Add(temp);
        }
    }
    private void readNames(string namesLine)
    {
        string[] names = namesLine.Split(new string[] { "\",\"" }, StringSplitOptions.None);
        for (int i = 0; i < testlist.Count; i++)
        { 
            testlist[i].name = names[i];
        }
    }
