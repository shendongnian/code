    protected void TestWrite(object sender, EventArgs e)
    {
        test test = new test();
        System.Diagnostics.Trace.Write(test.ToString());
    }
