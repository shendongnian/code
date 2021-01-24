    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
        var reg = Request["Welcome"]
           if(reg != null && reg.ToString() == "yes"){
              ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Insert Successfully')", true);
          }
       }
    }
