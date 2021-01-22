    public string GetPath(List<NavigationInfo> list, int itemId)
    {
        NavigationInfo item = list.SingleOrDefault(x => x.Id == itemId);
        if (item == null)
        {
            return "";
        }
        else
        {
            return GetPath(list, item.ParentId) + "\\" + itemId;
        }
    }
