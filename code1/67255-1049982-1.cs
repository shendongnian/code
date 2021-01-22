    public override IGroup GetByID(int id)
    {
        try
        {
            return (from g in this.Context.Groups
                    where g.GroupID == id && g.ActiveFlag
                    select this.BuildGroup(g)).Single();
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
