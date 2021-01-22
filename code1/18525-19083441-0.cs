    private void Page(int UpOrDown, ListView list)
            {
                //Determine if something is selected
                list.Focus();
                if (list.SelectedIndices.Count == 0)
                {
                    if (list.Items.Count > 0)
                    {
                        list.Items[0].Selected = true;
                        list.SelectedIndices.Add(0);
                        list.Items[0].Focused = true;
                        list.EnsureVisible(list.Items[0].Index);
                        list.TopItem = list.Items[0];
                    }
                }
                if (list.SelectedIndices.Count > 0)
                {
                    if (list.SelectedIndices[0] == null)
                    {
                        list.SelectedIndices.Add(0);
                    }
                    int oldIndex = list.SelectedIndices[0];
                    list.SelectedIndices.Clear();
    
                    //Use mod!
                    int numberOfItems = list.Items.Count;
                    if (oldIndex + UpOrDown >= 0 && oldIndex + UpOrDown <= list.Items.Count-1)
                    {
                        list.SelectedIndices.Add((oldIndex + UpOrDown)%numberOfItems);
                        list.SelectedItems[0].Selected = true;
                        list.SelectedItems[0].Focused = true;
                        list.EnsureVisible(list.SelectedItems[0].Index);
                        //list.TopItem = list.SelectedItems[0];
                    }
                }
            }
