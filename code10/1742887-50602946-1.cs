    [TestCase("myfile1.txt", "6677,6677_6677,3001,6")]
    [TestCase("myfile2.txt", "1,2,3")]
    public void mytest(string path, string expected) 
    {
        var actual = Common.LinuxCommandExecutor.
            RunLinuxcommand("cat " + path);
        Assert.AreEqual(expected, actual);
    }
