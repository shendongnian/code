    ViewBag.ItemsBag = db.Items.Select(v => new SelectListItem
    {
        Text = v.ItemName,
        Value = v.ItemId.ToString() // implies all values are strings
    });
