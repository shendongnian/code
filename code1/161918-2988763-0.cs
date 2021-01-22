    public void Contacts(string domainToBeTested, string[] browserList, string timeOut, int numberOfBrowsers, Action<ISelenium> callback)
    {
        verificationErrors = new StringBuilder();
        for (int i = 0; i < numberOfBrowsers; i++)
        {
            ISelenium selenium = new DefaultSelenium("LMTS10", 4444, browserList[i], domainToBeTested);
            try
            {
                // Here the delegate is called
                callback( selenium );
            }
            catch (AssertionException e)
            {
                verificationErrors.AppendLine(browserList[i] + " :: " + e.Message);
            }
            finally
            {
                selenium.Stop();
            }
        }
        Assert.AreEqual("", verificationErrors.ToString(), verificationErrors.ToString());
    }
