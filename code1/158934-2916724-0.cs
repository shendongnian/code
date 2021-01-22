    protected void Page_Load(object sender, EventArgs e) 
    {
        
             Label1.Text = "test";
            if (Request.QueryString["ID"] != null)
            {
        
                string test = Request.QueryString["ID"];
                Label1.Text = "Du har nu lånat filmen:" + test;
            }
    }
