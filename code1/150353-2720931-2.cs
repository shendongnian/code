    b.Items.Clear;
    for(int i=0; i<A.Items.Count; i++)
    {
        if (i!=A.SelectedItemIndex)
        {
        b.Items.Add(A.Items[i]);
        } 
    }
