    [TestMethod]
    public void PrintQuoteTest()
    {
        quote = new Quote();
        quote.InterestRate = 0.05M;
        Assert.AreEqual(
            "The interest rate is 0.05",
            PrintQuote(quote));
    }
