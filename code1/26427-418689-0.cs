    private int Step
    {
      get { return (int)Session["step"]; }
      set { Session["step"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
           Step = 0; // init
        else
           Step ++; // increment
        switch (Step)
        {
            //do something different for each step
        }
    }
