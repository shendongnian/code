    protected void Page_PreInit(object sender, EventArgs e)
    {
        imb = new ImageButton()
        {
            ID = "ID",
            ImageUrl = "link to image"
        };
        imb.Click += Imb_Click;
        Panel1.Controls.Add(imb);
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
