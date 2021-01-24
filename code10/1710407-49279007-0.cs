    var itemList = new ItemList();
    foreach (var itemField in itemList.GetType().GetFields())
    {
        var isUpdatedProp = itemField.FieldType.GetProperty("IsUpdated"); 
        if (isUpdatedProp != null)
        {
            var foo = itemField.GetValue(itemList);
            isUpdated = (bool)isUpdatedProp.GetValue(foo);
            if (!isUpdated) isUpdatedProp.SetValue(foo, true);
        }
    }
   
