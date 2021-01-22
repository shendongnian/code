    // USAGE
    [TestMethod]
    public void TestUrlBuilder()
    {
        Console.WriteLine(
            new UrlBuilder("http://www.google.com?A=B")
                .AddPath("SomePathName")
                .AddPath("AnotherPathName")
                .SetQuery("SomeQueryKey", "SomeQueryValue")
                .AlterQuery("A", x => x + "C"));
    }
