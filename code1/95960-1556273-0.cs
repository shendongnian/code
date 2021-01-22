    // Interface definition
    public ISearchForm
    {
        String Keywords { get; set; }
        int ItemsPerPage { get; set; }
        Action<string> SearchButtonClicked;
        // ...
    }
    // Implementation
    public SearchForm : ISearchForm
    {
        public String Keywords
        {
            get { return txtKeywords.Text; }
            set { txtKeywords.Text = value; }
        }
        // ...
    }
