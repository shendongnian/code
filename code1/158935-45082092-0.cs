      Label label1 = new System.Windows.Forms.Label
    //label1.Text = "test";
        if (Request.QueryString["ID"] != null)
        {
    
            string test = Request.QueryString["ID"];
            label1.Text = "Du har nu lånat filmen:" + test;
        }
    
       else
        {
    
            string test = Request.QueryString["ID"];
            label1.Text = "test";
        }
