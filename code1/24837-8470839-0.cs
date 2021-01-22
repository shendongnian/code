    @{
        var itemTypesList = new List<SelectListItem>();
    	itemTypesList.AddRange(Enum.GetValues(typeof(ItemTypes)).Cast<ItemTypes>().Select(
    				(item, index) => new SelectListItem
    				{
    					Text = item.ToString(),
    					Value = (index).ToString(),
    					Selected = Model.ItemTypeId == index
    				}).ToList());
     }
    @Html.DropDownList("ItemTypeId", itemTypesList)
