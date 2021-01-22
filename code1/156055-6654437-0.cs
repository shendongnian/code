    int unreadEmailCount = 0;
			SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
			ItemView view = new ItemView(999);
			FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
			unreadEmailCount = findResults.Items.Count;
