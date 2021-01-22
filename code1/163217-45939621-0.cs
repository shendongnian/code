    [SetUp]
    public void OnTestInitialize()
    {
        if (!UriParser.IsKnownScheme("pack"))
        {
           new Application();
        }
    }
    [TestCase]
    public void TestIfResourcesExist()
    {
	    var resources = new [] {
		    "pack://application:,,,/Tracto.UI.Infrastructure;component/Dictionaries/CommonColors.xaml",
		    "pack://application:,,,/Tracto.UI.Infrastructure;component/Dictionaries/CommonStyles.xaml",
		    "pack://application:,,,/Tracto.UI.Infrastructure;component/Dictionaries/GridSplitterStyle.xaml"
    	};
	    foreach (var mergedResource in resources)
    	{
    		// init
	    	ResourceDictionary dictionary =
		    	new ResourceDictionary {Source = new Uri(mergedResource, UriKind.RelativeOrAbsolute)};
    		// verify
	    	dictionary.Keys.Count.Should().BeGreaterThan(0);
    	}
    }
