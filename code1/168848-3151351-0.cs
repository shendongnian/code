    List<SelectListItem> items = new List<SelectListItem>();
    items.Add(new SelectListItem() { Text = "Test1", Value = "1", Selected = false });
    items.Add(new SelectListItem() { Text = "Test8", Value = "8", Selected = true });
    items.Add(new SelectListItem() { Text = "Test3", Value = "3", Selected = false });
    items.Add(new SelectListItem() { Text = "Test5", Value = "5", Selected = false });
    SelectList sl = new SelectList(items, "Value", "Text", "8");
