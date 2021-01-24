    var parent = new Parent()
    {
        p_name = "Best parent"
    };
    var child = new Child()
    {
        ch_name = "Best child",
        Parent = parent
    };
    using (var dc = new DataContext())
    {
        dc.Parents.InsertOnSubmit(parent);
        dc.Childs.InsertOnSubmit(child);
        dc.SubmitChanges();
    }
