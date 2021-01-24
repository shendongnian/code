    /// <summary>
    /// The elements with class1 or class2
    /// </summary>
    [FindsBy(How = How.xPath, Using = "//*[@class='class1' or @class='class2']")]
    [CacheLookup]
    public IList<IWebElement> Class1Class2Elements{ get; set; }
