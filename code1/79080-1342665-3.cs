    public Report()
    {
        InitializeComponent();
        rpViewer.RenderingComplete += new RenderingCompleteEventHandler(rpViewer_RenderingComplete);
        
    }
    void rpViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
    {
        int x = rpViewer.Find("0", 1);
    }
