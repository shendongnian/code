    protected void Page_Load(object sender, EventArgs e) {
       MyList.PagePropertiesChanged += new EventHandler(MyList_PagePropertiesChanged);
    }
    
    /// <summary>
    /// Handles the situation where the page properties have changed.  Rebind the data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MyList_PagePropertiesChanged(object sender, EventArgs e) {
       MyList.DataSource = GetSomeList();
       MyList.DataBind();
    }
