    using System.ComponentModel;
    private bool bShowGroup ;
    [Description("Show the group table"), Category("Sea"),DefaultValue(true)]
    public bool ShowGroup
    {
        get { return bShowGroup; }
        set { bShowGroup = value; }
    }
