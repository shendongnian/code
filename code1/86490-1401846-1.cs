    //Page that has the user control. 
    protected void Page_Load(object sender, EventArgs e)
    {
        this.test1.Count = 5;        
    }
    //User control code behind.
    public override DataBind() 
    {           
        aRepeater.DataSource = dal.GetObjects(this.Count);   
        base.DataBind(); 
    }
