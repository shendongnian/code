    public Item[] DataItems { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        // get your list
        DataItems = new[]
                        {
                            new Item{ ApplicationName = "Test", Url = new Uri("http://test.com/Home")},
                            new Item{ ApplicationName = "Test", Url = new Uri("http://test.com")},
                            new Item{ ApplicationName = "Test 2", Url = new Uri("http://test2.com/Home")},
                            new Item{ ApplicationName = "Test 2", Url = new Uri("http://test2.com/")},
                        };
    }
