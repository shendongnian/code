    protected void Page_Load(object sender, EventArgs e)
    {
        this.Controls.Add(CreateLiteral("text"));
        this.Controls.Add(CreateLiteral("text"));
        this.Controls.Add(CreateLiteral("text"));
    }
    
    private Literal CreateLiteral(string Content)
    {
        Literal L = new Literal();
        L.Text = Content;
        return L;
    }
