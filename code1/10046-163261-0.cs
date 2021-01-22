    var items = list.MyItems.Select(item => new { item.ID, item.Sector, item.Description, 
                                                  item.CompleteDate, item.DueDate })
                            .AsEnumerable() // Don't do the next bit in the DB
                            .Select(item => new { item.ID, item.Sector, item.Description,
                                                  CompleteDate = FormatDate(CompleteDate),
                                                  DueDate = FormatDate(DueDate) });
    static string FormatDate(DateTime? date)
    {
        return date.HasValue ? date.Value.ToShortDateString() : ""
    }
 
