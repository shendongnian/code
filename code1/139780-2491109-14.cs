        class CustomParameters
    {
        public int IntValue { get; set; }
        public string FriendlyMessage { get; set; }
    }
    
    private void CreateAndRunThreadsWithParams()
    {
        List<ParameterizedThreadStart> threadStartsList = new List<ParameterizedThreadStart>();
    
        //delegate creation
        for (int i = 0; i < 5; i++)
        {
            ParameterizedThreadStart ts = delegate(object o) { PrintCustomParams((CustomParameters)o); };
            threadStartsList.Add(ts);
        }
    
        //delegate execution
        for (int i=0;i<threadStartsList.Count;i++)
        {
            Thread t = new Thread(threadStartsList[i]);
            t.Start(new CustomParameters() { IntValue = i, FriendlyMessage = "Hello friend! Your integer value is:{0}"});
        }
    }
    
    private void PrintCustomParams(CustomParameters customParameters)
    {
        Debug.WriteLine(string.Format(customParameters.FriendlyMessage, customParameters.IntValue));
    }
