            foreach(var item in DATAsetname_INIlist)
        {
            checkedListBox2.Items.Add(item);
        }
        if (checkedListBox2.Items.Count != 0) {
            checkedListBox2.Items.Add("Select all");
        }
        private void checkedListBox2_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (checkedListBox2.Items.Count != 0 && checkedListBox2.SelectedItem.ToString().equals("Select all")) {
                changeStateOfSelectedItem("Deselect all", true);
            } else if (checkedListBox2.SelectedItem.ToString().equals("Deselect all")) {
                changeStateOfSelectedItem("Select all", false);
            }
        }
        private void changeStateOfSelectedItem (String state, bolean stateToReplace){
        for (int i = 0; i < checkedListBox2.Items.Count; i++) {
            checkedListBox2.SetItemChecked(i, stateToReplace);
        }
        string changed = state;
        checkedListBox2.SelectedItem = changed;
    
