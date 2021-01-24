    [TestMethod]
    public async Task SampleMethodTest()
    {
        using (StringWriter stringWriter = new StringWriter())
		{
			Console.SetOut(stringWriter);
            ClassName cn = new ClassName();
            await cn.SampleMethod();
        
            string consoleOutput = stringWriter.ToString();
            Assert.IsFalse(consoleOutput.Contains("Exception"));
        }
    }
