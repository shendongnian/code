    var fieldNames = new string[] {"bankCountryCode", "Currency" };
    foreach(var fieldName in fieldNames)
    {
        IEnumerable<string> fieldId = allItems.Select(m => 
        m.GetType().GetProperty(fieldName).GetValue(m, null)).Distinct();
        var fieldSL = new List<SelectListItem>();
    
        foreach (var element in fieldId)
        {
            // adding null check here until cosmos db with null tenant id's for tax are removed.
            if (element != null)
            {
                fieldSL.Add(new SelectListItem
                            {
                                Value = element.ToString(),
                                Text = element.ToString()
                            });
            }
        }
    
        fieldSL = fieldSL.OrderBy(x => x.Text).ToList();
        ViewBag.fieldIdList = fieldSL;
    }
        
