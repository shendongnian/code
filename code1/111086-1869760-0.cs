    string[] selectedColumns = new string[myListBox.SelectedItems.Count];
    for(int i = 0; i < myListBox.SelectedItems.Count; i++)
    {
        selectedColumns[i] = myListBox.SelectedItems[i].ToString();
    }
    string exportColumns = string.Join(",", selectedColumns);
    
    //format your sql statement
    string sqlStatement = string.Format("select {0} from YourTable WHERE blah=blah2", 
                                         exportColumns);
