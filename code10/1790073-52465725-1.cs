    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateButtons();
    }
    public void GenerateButtons()
    {
        AnotherClass anotherClass = new AnotherClass(this);
    }
    public void btnConfirmBook_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        DisplayConfirmation();
    }
    protected void DisplayConfirmation()
    {
        Panel1.Visible = false;
    }
