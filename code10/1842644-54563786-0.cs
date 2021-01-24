      for (int i = checkedListBox1.Items.Count; i >= 0; i--)
      {
        if (checkedListBox1.GetItemChecked(i))
        {
          checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[i]);
        }
      }
