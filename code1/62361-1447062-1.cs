    public bool topMost = false;
    public string description;
    public string title;
    public string url;
    public string target;
    public List<MenuItem> children;
    public MenuItem parent;
    public MenuItem(MenuItem parent)
    {
        children = new List<MenuItem>();
        if (parent != null)
        {
            this.parent = parent;
        }
    }
    public MenuItem()
    {
        children = new List<MenuItem>();
    }
