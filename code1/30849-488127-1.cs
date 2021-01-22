    var Issues = from i in db.Issues where i.Status == "Open" select i;
    switch (sort)
    {
        case "ID":
            Issues = Issues.OrderBy(i => i.ID);
            break;
        // [...]
        default:
            Issues = Issues.OrderBy(i => i.TimeLogged);
    }     
