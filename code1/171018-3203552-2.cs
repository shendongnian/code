    public IList<T> DoYourThing<T>(IList<T> items, IList<T> currentItems, Project project) where T : CommonBaseType
    {
      if (currentItems != null)
      {
        foreach (var existingItem in currentItems)
        {
          if (items.Contains(existingItem.Name))
            items.Remove(existingItem.Name);
          else
            existingItems.Delete(Services.UserServices.User);
        }
        foreach (string item in items)
        {
          T newItem = Activator.CreateInstance(typeof(T), new object[] {project, item.ToString()}) as T;
          newItem.Project = project;
          newItem.Save();
        }
      }
      return currentItems;
    }
