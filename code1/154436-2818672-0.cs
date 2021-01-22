    public void ExtractPageData()
    {
        // get stuff relevant to all pages that impmement OfflineFactsheetBase
        
        // base implementation
        ...
        // call derived class implementation
        this.ExtractPageDataInternal();
    }
    protected virtual void ExtractPageDataInternal()
    {
        // implementation to be defined by derived class
    }
