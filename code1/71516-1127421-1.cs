    public static void ListViewClicked(ListView listView)
    {
       if (listView.SelectedItem == null)
       {
          return;
       }
       if (ListViewItemLookup.ContainsKey(listView.SelectedItem))
       {
          ListViewItemLookup[listView.SelectedItem].Execute();
       }
    }
