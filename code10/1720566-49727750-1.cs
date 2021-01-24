    using (var myDbContext = new DbContext(...))
    {
        IQueryable myEls = myDbContext.el;
        var mySelectedItems = myEls.SelectAndSore(
            // selector: what properties do I as a user want?
            el => new
            {
                 Id = el.Id,
                 FullName = el.FullName,
                 ... // other desired properties
            },
            // sortSelector: how do I want my selected items to be sorted?
            selectedItem => selectedItem.FullName,
            // direction:
            ListSortDirection.Descending);
            // note: until now the database has not been accessed
            // only the Expression of the query has been created.
            // depending on what you want as a result: ToList / ToArray / First / ...
            return mySelectedItems.ToList();
        }
