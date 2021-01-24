    void testIList<T>(System.Collections.Generic.IList<T> someList)
    {
        for (int i = 0; i < someList.Count; i++)
        {
            someList[i] = default(T);
        }
    }
