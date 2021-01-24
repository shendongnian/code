    for (int i = 0; i < checkedListBox.Items.Count; i++) {
        string text;
        if (checkedListBox.GetItemChecked(i)) {
            text = checkedListBox.Items[i] + "-True";
        }
        else {
            text = checkedListBox.Items[i] + "-False";
        }
        // do something with text here
    }
