    public ActionResult Result()
    {    
        var items = _dataItems.Select(item => 
                    new KeyValuePair<int, string>(_keySelector.Compile().Invoke(item), _valueSelector.Compile().Invoke(item)))
                    .ToDictionary(item => item.Key, item => item.Value);
    
        items.Add(0, "");
    
        var list = new SelectList(items.OrderBy(i => i.Value), "Key", "Value", _selectedID);
    
        return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };    
    }
