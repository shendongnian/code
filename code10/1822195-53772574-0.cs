    // MultiSelectList approach
    ViewBag.SelectedServiceLines = new MultiSelectList(db.LookUps.Where(lu => lu.RecordType == "ServLine"), "ID", "Description", funder.SelectedServiceLines.ToList());
    // IEnumerable<SelectListItem> approach
    ViewBag.SelectedServiceLines = db.LookUps.Where(lu => lu.RecordType == "ServLine")
                                             .Select(i => new SelectListItem() { 
                                                          Text = i.Description, 
                                                          Value = i.Id, 
                                                          Selected = funder.SelectedServiceLines.Contains(i.Id) 
                                   }).ToList();
