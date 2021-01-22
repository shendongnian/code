    private void BuildSortTree(int sel)
    		{
    			MergeSort.Items.Clear();
    			TreeViewItem itTemp = new TreeViewItem();
    			itTemp.Header = SortList[0];
    			MergeSort.Items.Add(itTemp);
    			TreeViewItem prev;
    			itTemp.IsExpanded = true;
    			if (0 == sel) itTemp.IsSelected= true;
    			prev = itTemp;
    			for(int i = 1; i<SortList.Count; i++)
    			{
    
    				TreeViewItem itTempNEW = new TreeViewItem();
    				itTempNEW.Header = SortList[i];
    				prev.Items.Add(itTempNEW);
    				itTempNEW.IsExpanded = true;
    				if (i == sel) itTempNEW.IsSelected = true;
    				prev = itTempNEW ;
    			}
    		}
