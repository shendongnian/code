    public int GetMinVal(Test initialTest, out Test testWithMinVal)
    {
        int minVal = initialTest.val;
        testWithMinVal = initialTest;
        foreach (Test t in initialTest.Tests)
        {
            if (t.val < minVal)
            {
                minVal = GetMinVal(t, out testWithMinVal);
            }
        }
        return minVal;
    }
