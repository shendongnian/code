     public List<T> Search(string searchText)
        {
            List<T> results = new List<T>();
            foreach (HierarchyItem item in items)
            {
                if (item.DisplayText().ToLower().Contains(searchText.ToLower()))
                {
                     T castedItem = item as T;
                     if(castedItem != null )
                          results.Add(item);
                }
            }
    
            return results; 
        }
