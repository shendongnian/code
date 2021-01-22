    //list of predicate functions to check
    var conditions = new List<Predicate<MyClass>> 
    {
        x => string.IsNullOrEmpty(ddlFileName.SelectedItem.Text) ||
             x.FileName.Contains(ddlFileName.SelectedValue),
        x => !chkFileName.Checked ||
             string.IsNullOrEmpty(x.FileName),
        x => string.IsNullOrEmpty(ddlIPAddress.SelectedItem.Text) ||
             x.IpAddress.Contains(ddlIPAddress.SelectedValue),
        x => !chkIPAddress.Checked ||
             string.IsNullOrEmpty(x.IpAddress)
    }
    //now get results
    var results =
        from x in GetInitialResults()
        //all the condition functions need checking against x
        where conditions.All( cond => cond(x) )
        select x;
