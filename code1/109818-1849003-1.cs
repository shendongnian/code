    MyCombo.SelectedIndexChanged += new System.EventHandler(MyCombo_SelectedIndexChanged);
    private void MyCombo_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // this will depend on what your column names are, obviously
        string filter = string.Format("GroupID = {0}", MyCombo.SelectedValue);
        bsUser.Filter = filter;
    }
