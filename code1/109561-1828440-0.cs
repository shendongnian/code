        public void SelectQueryResultItem(WorkItem item)
        {
            // Because the ListBox only compares by reference, 
            //  we need to find the matching WorkItem (if any)
            //  before adding it to the selected list.
            WorkItem matchingWorkItemInList = GetWorkItemInQueryResultByID(item.Id);
            if (matchingWorkItemInList != null)
                lstQueryResults.SelectedItems.Add(matchingWorkItemInList);
        }
        public WorkItem GetWorkItemInQueryResultListByID(int Id)
        {
            foreach (WorkItem workItem in lstQueryResults.Items)
            {
                if (workItem.Id == Id)
                {
                    return workItem;
                }
            }
            return null;
        }
