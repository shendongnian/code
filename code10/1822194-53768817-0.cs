    // Use List<SelectListItem> instead
    ViewBag.SelectedServiceLines = 
        db.LookUps
            .Where(lu => lu.RecordType == "ServLine")
            .Select(i => new SelectListItem() { Text = i.Description, Value = i.Id })
            .ToList();
