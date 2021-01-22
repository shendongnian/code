            if (!IsPostBack)
            {
                if (Session["something"] == null)
                {
                    Session["something"] = "1";
                }
                else
                {
                    Session["something"] = null;
                    //
		      your page load code here 
		   //
                }
               
            }
        }
