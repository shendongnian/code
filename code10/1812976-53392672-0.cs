    void TestIList(IList<int> someList)
    {
    	for (int i = 0; i < someList.Count; i++)
    	{
    		someList[i] = someList.Count - i;
    	}
    }
