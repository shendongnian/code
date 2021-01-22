    protected void TestWrite(object sender, EventArgs e)
    {
        test test = new test();
        object testObject = test;
        System.Diagnostics.Trace.Write(testObject.ToString());
    }
