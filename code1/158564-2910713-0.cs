        if (Session["UserName"] != null)
        {
            //Retrieving UserName from Session
            lblWelcome.Text = "Welcome : " + Session["UserName"];
        }
        else
        {
         //Do Something else
        }
