     void GetChild(IEnumerable<Process> data, int? parentId = null)
    {
        var items = data.Where(d => d.Parent_Id == parentId).OrderBy(i => i.MenuOrder);
        if (items.Any())
        {
            foreach (var item in items)
            {
                //Each Item is your child 
                GetChild(data, item.ID);
            }
        }
    }
