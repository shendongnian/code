    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "lemmatizations.csv", "lemmatizations#csv", DataAccessMethod.Sequential)]
    [TestMethod]
    public void LemmatizationTest()
    {
        string lemma = TestContext.DataRow["lemma"]);
        string expected = TestContext.DataRow["expected"]);
        Assert.AreEqual(expected, lemma);
    }
