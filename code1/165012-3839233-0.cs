    /// <summary>
    /// Gets the page Basedata.
    /// </summary>
    /// <returns>The content or null if not on a PageBuilder layout</returns>
    private ContentBase GetPageBasedata()
    {
        PageBuilder myPage = this.Page as PageBuilder;
        if (myPage != null)
        {
            return myPage.Basedata;
        }
        return null;
    }
