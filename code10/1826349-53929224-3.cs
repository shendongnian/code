    if (!String.IsNullOrWhiteSpace(searchValue))
    {
         expheadlist = expheadlist.Where(e => (string.IsNullOrWhiteSpace(e.Name) || e.Name.ToLower().Contains(searchValue))
                        || (string.IsNullOrWhiteSpace(e.Description) || e.Description.ToLower().Contains(searchValue))
                        ).ToList<GenExpenseHead>();
    }
