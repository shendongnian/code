    using (var ctx = new MyDataContext())
    {
        var qry = ctx.BaseEntities.OfType<DerivedEntity>();
        IListSource ls = (IListSource)qry;
        IList list = ls.GetList(); // boom
        /* Constructor on type
           'System.Data.Linq.Provider.DataBindingList`1[snip]'
           not found.*/
    }
