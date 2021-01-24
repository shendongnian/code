        if (!IsPostBack)
			{
            if (Request.QueryString["entry1"] != null && 
             Request.QueryString["entry2"] != null)
            {
                input1.Value = Request.QueryString["entry1"];
                input2.Value = Request.QueryString["entry2"];
                CompareFSUI();
            }
           }
        }
`
