    // if only str is provided
     if (string.IsNullOrEmpty(item.KeyInfo) && !string.IsNullOrEmpty(str))
     {
        ModelState.Clear();
        Helpers.FillItemModel(item, str);   //fill data
     }
