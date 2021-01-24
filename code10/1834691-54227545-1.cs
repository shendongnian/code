    List<string> toSort = new List<string>();    
    
    foreach (var item in FileCabinetsRetrieved.SelectedItems)
            {
                FileCabinetsRetrieved.Items.Remove(item);
                toSort.Add(item);
            }
    foreach (var item in FileCabinetsToAdd.Items)
            {
                toSort.Add(item);
            }
    
    toSort = toSort.OrderBy(x => x).ToList();
    FileCabinetsToAdd.Items.Clear();
    foreach (var item in toSort)
    {
        FileCabinetsToAdd.Items.Add(item);
    }
