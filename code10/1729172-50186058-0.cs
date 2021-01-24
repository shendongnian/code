    private void geckoWebBrowser_DomClick(object sender, Gecko.DomMouseEventArgs e)
    {
        DomClicked();
    }
    
    private string _selectedFeature;
    public string SelectedFeature
    { 
        get 
        {
            GBDomClick();
            return _selectedFeature;
        }
        private set { _selectedFeature= value; }
    }
