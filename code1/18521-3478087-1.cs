    int oldSelection = ListView1.SelectedIndices[0];
    if(*NextOptionSelected* && oldSelection + 1 < ListView1.Items.Count)
    {
         ListView1.Items[oldSelection + 1].Selected = true;
         ListView1.Items[oldSelection + 1].Focused = true;
         ListView1.Items[oldSelection].Selected = false;
         ListView1.Items[oldSelection].Focused = false;
    }
    else if(*LastOptionSelected* && oldSelection > 0)
    {
         ListView1.Items[oldSelection - 1].Selected = true;
         ListView1.Items[oldSelection - 1].Focused = true;
         ListView1.Items[oldSelection].Selected = false;
         ListView1.Items[oldSelection].Focused = false;
    }
               
    ListView1.EnsureVisible(ListView1.SelectedIndices[0]);
