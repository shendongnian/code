    for(int ixPerson = myListView.Items.Count - 1; ixPerson >= 0; ixPerson--)
    {
       ListViewItem personItem = myListView.ItemContainerGenerator.ContainerFromIndex(ixPerson);
       if (personItem.IsSelected)
       {
          mySourcePersonCollection.RemoveAt(ixPerson);
       }
    }
