    public event SelectedIndexChanged;
    public void PageLoad()
    {
        radioList.SelectedIndexChanged += new EventHandler(RadSelectedIndexChanged);
    }
    public void RadSelectedIndexChanged(object sender, EventArgs args)
    {
        SelectedIndexChanged(sender, args);
    }
