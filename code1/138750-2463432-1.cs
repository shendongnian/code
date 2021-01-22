    protected void btnSearchButton_Click(object sender, EventArgs e)
    {
        //store the values of the form in session
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //check if the values are in session. 
            //If so, remove them and use them to bind the grid.
        }
    }
