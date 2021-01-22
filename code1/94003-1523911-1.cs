    protected void DeleteRecord(object sender, CommandEventArgs e)
    {
        Guid id = new Guid((string)e.CommandArgument);
        if (RemoveData(id))
        {
        }
    }
