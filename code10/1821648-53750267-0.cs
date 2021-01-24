    List<multiSearchSelect> multiSearchSelect = new List<multiSearchSelect>();
    private void FilesFoundList_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
            {
                if (FilesFoundList.VirtualMode == true)
                {
                    multiSearchSelect.Clear();
    
                    ListView.SelectedIndexCollection col = FilesFoundList.SelectedIndices;
                    if (col.Count > 1)
                    {
                        foreach (int item in col)
                        {
                            multiSearchSelect.Add(new multiSearchSelect
                            {
                                fileName = FilesFoundList.Items[item].SubItems[1].Text,
                                filePath = FilesFoundList.Items[item].SubItems[2].Text
                            });
                        }
                    }
                }
            }
    class multiSearchSelect
        {
            public string fileName { set; get; }
            public string filePath { set; get; }
        }
