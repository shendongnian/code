    public static List<SelectListItem> ToSelectList(this List<Agent> users)
    {
        List<SelectListItem> items = new List<int>();
        foreach (var user in users)
        {
            var item = new SelectListItem { Text = user.FriendlyName, 
                                    Value = user.UserId.ToString() };
    
            if (User.Identity.Name == user.UserName)
                item.Selected = true;
    
            items.Add(item);
        }
    
        return items;
    }
