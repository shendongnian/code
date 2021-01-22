    void moveListBoxItem(CheckedListBox list, int oldIndex, int newIndex ) {
      var state = list.GetItemCheckedState(oldIndex);
      object old = list.Items[oldIndex];
      list.Items.RemoveAt(oldIndex);
      list.Items.Insert(newIndex, old);
      list.SetItemCheckedState(newIndex, state);
    }
