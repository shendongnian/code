    public IEnumerable<SelectListItem> GetStaff()
    {
        List<SelectListItem> staffSelectListItems = _db.Staff.OrderBy(n => n.FirstName)
                                       .Select(n => new SelectListItem
                                       {
                                           Value = n.StaffID.ToString(),
                                              Text = n.FirstName.ToString() + " " + n.LastName.ToString()
                                       }).ToList();
        var defaultSelection = new SelectListItem()
        {
                    Value = "0",
                    Text = "Select Staff Member",
                    Selected = true // <-- this is obligatory
        };
        staffSelectListItems.Insert(0, defaultSelection);
        return staffSelectListItems;
    }
