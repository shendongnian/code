    List<SelectListItem> selectListItems = new List<SelectListItem>();
    
        foreach (var item in typeof(PaymentTerm).GetEnumValues())
        {
            var type = item.GetType();
            var name = type.GetField(item.ToString()).GetCustomAttributesData().FirstOrDefault()?.NamedArguments.FirstOrDefault().TypedValue.Value.ToString();
            selectListItems.Add(new SelectListItem(name, type.Name));
    
        }
