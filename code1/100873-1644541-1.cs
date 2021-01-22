    private void MoveSelItems(ListBox from, ListBox to)
        {
            for (int i = 0; i < from.SelectedItems.Count; i++)
            {
                to.Items.Add(from.SelectedItems[i].ToString());
                from.Items.Remove(from.SelectedItems[i]);
            }
        }
