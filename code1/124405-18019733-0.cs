    [TestMethod]
    public void RegExTest()
    {
        //Regex compiler: (?:\G|[^\\])(?<MyGroup>"(?:[^"\\]*(?:\.)*)*")
        string pattern = "(?:\\G|[^\\\\])(?<MyGroup>\"(?:[^\"\\\\]*(?:\\\\.)*)*\")";
        var r = new Regex(pattern, RegexOptions.IgnoreCase);
    
        //Human readable form:       "Some Text"  and  "Even more Text\""     "Even more text about  \"this text\""      "Hello\\"      \"foo\"  - "bar"  "a"   "b" c "d"
        string inputWithQuotedText = "\"Some Text\" and \"Even more Text\\\"\" \"Even more text about \\\"this text\\\"\" \"Hello\\\\\" \\\"foo\\\"-\"bar\" \"a\"\"b\"c\"d\"";
        var quotedList = new List<string>();
        for (Match m = r.Match(inputWithQuotedText); m.Success; m = m.NextMatch())
            quotedList.Add(m.Groups["MyGroup"].Value);
                
        Assert.AreEqual(8, quotedList.Count);
        Assert.AreEqual("\"Some Text\"", quotedList[0]);
        Assert.AreEqual("\"Even more Text\\\"\"", quotedList[1]);
        Assert.AreEqual("\"Even more text about \\\"this text\\\"\"", quotedList[2]);
        Assert.AreEqual("\"Hello\\\\\"", quotedList[3]);
        Assert.AreEqual("\"bar\"", quotedList[4]);
        Assert.AreEqual("\"a\"", quotedList[5]);
        Assert.AreEqual("\"b\"", quotedList[6]);
        Assert.AreEqual("\"d\"", quotedList[7]);
    }
