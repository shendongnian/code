    public void BuildQuery(string connection) 
    {
        using (var db = new DataContext(connection))
        {
            action = db.GetTable<ActionType>().Select(a=>a);
            ActionType at = new ActionType();
            at.Name = "New Action Type";
            // What now? action.add(at) || db.GetTable<ActionType>.add(at); ??
            db.ActionTypes.InsertOnSubmit(at);
            db.SubmitChanges();
        }
    }
