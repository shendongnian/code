    // Initialize model
    var model = new ManifestFilterDropDownItem
    {
        States = new List<SelectListItem>
    }
    var states = data.GroupBy(x => x.AddrState); // group by state
    foreach (var group in states)
    {
        // Create a SelectListGroup
        var optionGroup = new SelectListGroup() { Name = group.Key };
        // Add SelectListItem's
        foreach (var item in group)
        {   
            model.States.Add(new SelectListItem()
            {
                Value = item.AddrZip,
                Text = item.AddrZip,
                Group = optionGroup
            })
        }
    }
    return model;
