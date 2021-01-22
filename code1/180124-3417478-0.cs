    protected void litCount_DataBinding(object sender, System.EventArgs e)
    {
        _itemCounter++;
        Literal lt = (Literal)(sender);
        lt.Text = _itemCounter.ToString();
    }
