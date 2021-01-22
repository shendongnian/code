    using (var consoleOutput = new ConsoleOutput())
    {
        target.WriteToConsole(text);
        Assert.AreEqual(text, consoleOutput.GetOuput());
    }
