    @{
       List<SelectListItem> listItems= new List<SelectListItem>();
       listItems.Add(new SelectListItem
            {
              Text = "Public",
              Value = "1"
            });
       listItems.Add(new SelectListItem
            {
                Text = ""Friends Only"",
                Value = "2"
            });
       listItems.Add(new SelectListItem
            {
                Text = "Private",
                Value = "3"
            });
    }
    
    @Html.DropDownListFor(model => model.profileSettings, listItems, "Select Option")
