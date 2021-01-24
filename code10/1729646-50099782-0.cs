    protected void gv_Quals_RowCommand(object sender, EventArgs e)
    {
         ImageButton btn = (ImageButton)sender;
         string cmName= btn.CommandName;
         string cmArgument= btn.CommandArgument;
         if ((cmName == "Remove"))
         {
            ..... 
         }
    }
