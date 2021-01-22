    /// <summary>
    ///A test for ToString
    ///</summary>
    [Test]
    [RowTest(@"c:\temp\input2005.txt", @"c:\temp\output2005.txt")]
    [RowTest(@"c:\temp\input2006.txt", @"c:\temp\output2006.txt")]
    [RowTest(@"c:\temp\input2007.txt", @"c:\temp\output2007.txt")]
    public void ToStringTest(string inputFile, string outputFile)
    {
        string input = System.IO.File.ReadAllText(inputFile);
        MyClass target = new MyClass(input);
        string expected = System.IO.File.ReadAllText(outputFile);
        string actual;
        actual = target.ToString();
        Assert.AreEqual(expected, actual);
    }
