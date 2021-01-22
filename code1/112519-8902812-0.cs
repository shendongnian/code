    bool bGetSelectCount;
    protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (bGetSelectCount)
            TextBox1.Text = e.ReturnValue.ToString(); 
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        bGetSelectCount = e.ExecutingSelectCount;
    }
