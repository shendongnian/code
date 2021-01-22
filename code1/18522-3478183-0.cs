    //UpOrDown is a +1 or -1
    void Page(int UpOrDown){
        //Determine if something is selected
        if (listView.SelectedIndices.Count > 0)
            {
                int oldIndex = listView.SelectedIndices(0);
                listView.SelectedIndices.Clear();
                
                //Use mod!
                int numberOfItems = listView.Items.Count();
                listView.SelectedIndices.Add((oldIndex + UpOrDown) % numberOfItems)
            }
    }
