    public void qc_GetOfficerNamesCompleted(object sender, GetOfficerNamesCompletedEventArgs e) 
    { 
    // Now try adding this code
    for(int i=0; i<e.Result.Count;i++)
    {
        Items.Add(e.Result[i]); //Add individual item in the returning ObservableCollection to the items Collection
    }
    } 
