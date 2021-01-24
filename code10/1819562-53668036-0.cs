    ExchangeService service = EmailCredentials();
    
    // Return only folders that contain items.
    SearchFilter searchFilter = new SearchFilter.IsGreaterThan(FolderSchema.TotalCount, 0);
    
    // Unlike FindItem searches, folder searches can be deep traversals.
    view.Traversal = FolderTraversal.Deep;
    
    // Send the request to search the mailbox and get the results.
    FindFoldersResults findFolderResults = service.FindFolders(WellKnownFolderName.Root, searchFilter, view);
    
    foreach (var folder in findFolderResults)
    {
        FindItemsResults<Item> findResults = service.FindItems(folder, new ItemView(CountRec));
    
        foreach (Item i in findResults.Items)
        {
            countOfEmails++;
        }
    }
