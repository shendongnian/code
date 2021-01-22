    public void SetPage(int page)
    {
        gridMain.PageIndex = Math.Max(page, gridMain.PageCount);
        gridMain.DataBind();
    }
