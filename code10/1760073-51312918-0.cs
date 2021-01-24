    Items = (from Item in GetList()
        select new SelectListItem
        {
            Selected = string.Equals(Item.Value, formTypeSelected, StringComparison.IgnoreCase),
            Text = Item.Key,
            Value = Item.Value                               
        }).ToList();
