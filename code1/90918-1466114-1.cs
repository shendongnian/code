    public static List<SelectListItem> ToSelectList(this List<Agent> users, 
                                                            string selectedUserName)
    {
        List<SelectListItem> items = new List<int>();
        foreach (var user in users)
        {
            var item = new SelectListItem { Text = user.FriendlyName, 
                                    Value = user.UserId.ToString() };
    
            if (user.UserName == selectedUserName)
                item.Selected = true;
    
            items.Add(item);
        }
    
        return items;
    }
