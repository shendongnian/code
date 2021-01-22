    [TestMethod]
    public void ValidateConsoleOutput()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            ConsoleUser cu = new ConsoleUser();
            cu.DoWork();
            string expected = string.Format("Ploeh{0}", Environment.NewLine);
            Assert.AreEqual<string>(expected, sw.ToString());
        }
    }
