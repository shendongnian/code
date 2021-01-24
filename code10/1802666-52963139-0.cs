    public List<Custom> currList;
    List<Custom> lastFrameList;
    void Update()
    {
        if (lastFrameList != null)
        {
            Debug.Log("lastFrameList is not null");
            foreach (Custom c in currList)
            {
                if (!lastFrameList.Contains(c)
                {
                    Debug.Log("there is a new element in currList that was not there in lastFrameList");
                    DoStuff()
                }
             }
         }
         lastFrameList = currList;
    }
