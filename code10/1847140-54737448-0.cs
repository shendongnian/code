            public IEnumerable<SelectListItem> GetStaff()
        {
    
                List <SelectListItem> selectListItems = _db.Staff.AsNoTracking()
                    .OrderBy(n => n.FirstName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.StaffID.ToString(),
                            Text = n.FirstName.ToString() + " " + n.LastName.ToString()
                        }).ToList();
                var stafftip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select staff memeber---"
                };
                selectListItems.Insert(0, stafftip );
                return new SelectList(selectListItems, "Value", "Text");
    
       }
