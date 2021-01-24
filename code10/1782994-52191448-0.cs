    List<int> testList = new List<int>{1,76,3,4,5,76,76,8};
    
    public void RemoveElements()
    {
        for (int i = testList.Count - 1; i >= 0; i--)
        {
            // RemoveAt option
            if(testList[i] == 76) testList.RemoveAt(i);
        }
    }
