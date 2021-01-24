    [TestMethod]
    public void CodedUITestMethod1()
    {
        CodedUITestMethod1Helper();
    }
    public void CodedUITestMethod1Helper()
    {
        ... some test code ...;
        if (something)
        {
           ... more test code ...;
        }
        else
        {
           // Test is aborted here; but marked as Completed
           return;
        }
        ... some test code ...;
        if (something else)
        {
           ... more test code ...;
        }
        else
        {
           // Test is aborted here; but marked as Completed
           return;
        }
        ... some test code ...;
    }
