        private ArrayList getItemsFromListViewControl()
    {                      
        ArrayList lviItemsArrayList = new ArrayList();
        foreach (ListViewItem itemRow in this.loggerlistView.Items)
        {
            //lviItemsArrayList.Add(itemRow.Text); <-- Already included in SubItems so ... = )
            for (int i = 0; i < itemRow.SubItems.Count; i++)
            {
                lviItemsArrayList.Add(itemRow.SubItems[i].Text);
                // Do something useful here, for example the line above.
            }
        }
        return lviItemsArrayList;
    }
