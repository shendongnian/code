    lisSerials.Items.Clear();
    lisSerials.View = View.Details;
    lisSerials.FullRowSelect = true;
    
    // add column if not already present
    if(lisSerials.Columns.Count==0)
    {
        int vw = SystemInformation.VerticalScrollBarWidth;
        lisSerials.Columns.Add("Serial Numbers", lisSerials.Width-vw-5);
    }
                    
    foreach (string s in stringArray)
    {
        ListViewItem lvi = new ListViewItem(new string[] { s });
        lisSerials.Items.Add(lvi);
    }
