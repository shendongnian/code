    private DataContext db;
    private IQueryable<ActionType> action;
    public void BuildQuery(string connection) {
       db = new DataContext(connection);
       action = db.GetTable<ActionType>().Select(a=>a);
       ActionType at = new ActionType();
       at.Name = "New Action Type";
       //There must be a table like ActionType and it seems ActionTypes when calling it ith   // db
       db.ActionTypes.InsertOnSubmit(at);
       db.SubmitChanges();
    }
