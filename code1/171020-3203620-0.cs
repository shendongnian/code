    public void SaveNewItems<T>(IList<string> newList, IList<T> currentList, string project)
        where T: new(), IStoreableItem
    {
        //find only new items
        var toAdd = from itemName in newList
                    where !currentList.Contains(i => i.Name = itemName)
                    select new T {
                        Name = itemName,
                        Project = project
                    };
    
        //find items to delete
        var toDelete = from item in currentList
                       where !newList.Contains(item.Name)
                       select item;
        toAdd.ToList().ForEach(item => item.Save());
        toDelete.ToList().ForEach(item => item.Delete());
    }
