    protected void Page_Init(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //Check for your conditions here, 
                
                if (Page.IsAsync)
                {
                    //also you may want to handle Async callbacks too:
                }
            }
        }
