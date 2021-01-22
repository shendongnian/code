    public event EventHandler UserControlButtonClicked;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            renderPage();
        }
    }
    private void OnUserControlButtonClick()
    {
        if (UserControlButtonClicked != null)
        {
            UserControlButtonClicked(); 
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        OnUserControlButtonClick();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        OnUserControlButtonClick();
    }
