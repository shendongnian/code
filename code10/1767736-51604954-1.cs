    protected class AnObject
    {
        public AnObject(int uid, string photolabel)
        {
            this.UserID = uid;
            this.PhotoLabel = photolabel;
        }
        public int UserID { get; set; }
        public string PhotoLabel { get; set; }
    }
    protected void Execute()
    {
        List<AnObject> sortedList = new List<AnObject>();
        sortedList.Add(new AnObject(92, "anystring"));
        sortedList.Add(new AnObject(92, "anystring"));
        sortedList.Add(new AnObject(92, "anystring"));
        sortedList.Add(new AnObject(88, "anystring"));
        sortedList.Add(new AnObject(88, "anystring"));
        sortedList.Add(new AnObject(4, "anystring"));
        sortedList.Add(new AnObject(1, "anystringfirst"));
        sortedList.Add(new AnObject(1, "anystringfirst"));
        sortedList.Add(new AnObject(1, "anystringfirst"));
        sortedList.Add(new AnObject(32, "anystring"));
        sortedList.Add(new AnObject(32, "anystring"));
        sortedList.Add(new AnObject(32, "anystring"));
        sortedList.Add(new AnObject(32, "anystring"));
        sortedList.Add(new AnObject(1, "anystringafter"));
        sortedList.Add(new AnObject(1, "anystringafter"));
        sortedList.Add(new AnObject(1, "anystringafter"));
        List<AnObject> bb = aFunction(sortedList);
    }
