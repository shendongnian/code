    /// <summary>
    /// Cleanup that stops the chrome browser
    /// </summary>
    [TestCleanup]
    public void CloseBrowser()
    {
        Driver.Quit();
    }
