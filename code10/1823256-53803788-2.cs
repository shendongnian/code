    //In Class2
    public void PopulateListBox(ListBox grd) 
    {
        for (int i = 0; i < names.Length; i++)
        {
            grd.Items.Add(names[i]);
        }
    }
