    protected void Page_PreInit(object sender, EventArgs e)
    {
        imb = new ImageButton()
        {
            ID = "ID",
            ImageUrl = "link to image"
        };
        imb.Attributes.Add("runnat", "server");
        imb.Click += Imb_Click;
        Controls.Add(imb);
    }
    private void Imb_Click(object sender, ImageClickEventArgs e)
    {
        // Do your stuff
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set initial properties as appropriate. E.g.
            imb.AlternateText = "...";
        }
    }
