     protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ListView1.DataSource = ...
                ListView1.DataBind();
    
                //if you know its empty empty data template is the first parent control
                // aka Controls[0]
                Control c = ListView1.Controls[0].FindControl("Literal1");
                if (c != null)
                {
                    //this will atleast tell you  if the control exists or not
                }
    
                
    
            }
        }
    
