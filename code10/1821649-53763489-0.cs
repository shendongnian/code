    List<multiSearchSelect> multiSearchSelect = new List<multiSearchSelect>();
    private void FilesFoundList_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
    {
        if (FilesFoundList.VirtualMode == true)
        {
            multiSearchSelect=
                FilesFoundList.SelectedIndices
	            .Select(i=> new multiSearchSelect()
	            { 
		            fileName = FilesFoundList.Items[i].SubItems[1].Text, 
		            filePath = FilesFoundList.Items[item].SubItems[2].Text
	            });
        }
    }
    class multiSearchSelect
    {
        public string fileName { set; get; }
        public string filePath { set; get; }
    }
