    foreach (ListViewItem Item in LstvClients.Items)
    {    
         if (item.Selected)
         {
             LstvClients.Items.Remove(Item);
         }
    }
