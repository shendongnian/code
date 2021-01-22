    protected void Page_Load(object sender, EventArgs e)
    {
       var test  = Request["ornProperties"];
       if (!String.IsNullOrEmpty(Request.Params["ornTest"]))
       {
           string paramVars = Request.Params["ornTest"];
           Response.Clear(); //just to make sure you're not sending anything else.
           Response.Write("this string");
       }
    }
