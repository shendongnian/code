    protected void theGridView_DataBound(object sender, EventArgs e)
    {
        SetTabIndexes();
    }
 
    private void SetTabIndexes()
    {
        short currentTabIndex = 0;
        inputFieldBeforeGridView.TabIndex = ++currentTabIndex;
 
        foreach (GridViewRow gvr in theGridView.Rows)
        {
            DropDownList dropDown1 = (DropDownList)gvr.FindControl("dropDown1");
            dropDown1.TabIndex = ++currentTabIndex;
 
            TextBox inputField1 = (TextBox)gvr.FindControl("inputField1");
            inputField1.TabIndex = ++currentTabIndex;
 
            TextBox inputField2 = (TextBox)gvr.FindControl("inputField2");
            inputField2.TabIndex = ++currentTabIndex; 
 
            TextBox inputField3 = (TextBox)gvr.FindControl("inputField3");
            inputField3.TabIndex = ++currentTabIndex;
        }
        someLinkAfterGridView.TabIndex = ++currentTabIndex;
    }
