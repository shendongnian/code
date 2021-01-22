    protected void MyListDataBound(object sender, EventArgs e)
    {
        MyList.Items.Insert(0, new ListItem("- Select -", ""));
    }
    
    protected void MyListDataBinding(object sender, EventArgs e)
    {
        MyList.Items.Items.Clear();
    }
