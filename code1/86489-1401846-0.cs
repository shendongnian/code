    //User control code behind.  GetCount() returns an int.
    public override DataBind() {
       
        aRepeater.DataSource = dal.GetObjects(GetCount());   
        base.DataBind(); 
    }
