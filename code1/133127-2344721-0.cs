     protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           if(Session["AttemptCount"] == null)
           {
              Session["AttemptCount"]=new Hashtable(); //Because of this line.
           }
        }   
    }
