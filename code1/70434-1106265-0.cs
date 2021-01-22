    foreach (DataRow r in ds.Tables[0].Rows)
    {
        string prodCode = r["PRD-CDE"].ToString();
        string statCode = r["STAT"].ToString();
        DateTime firstIssueDate = DateTime.Parse((r["FISS"]).ToString()); 
        DateTime endIssueDate = DateTime.Parse((r["EISS"]).ToString());
        if(endIssueDate > DateTime.Now)
        { /*do some thing...*/}
        else {/*user invalid...*/}
    }
