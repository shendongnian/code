    using (var context = new IMToolDataContext())
    {
        ddlContracts.DataValueField = GetKeyColumnName(typeof(Metadata));
        ddlContracts.DataTextField = GetNameColumnName(typeof(Metadata));
        ddlContracts.DataSource = context
            .AllContracts
            .OrderBy(o => o.Name);
        ddlContracts.DataBind();
    }
