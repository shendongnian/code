    List<string> checkedItems = new List<string>();
    for(int i = 0; i < checkBoxes.Length; i++) {
        CheckBox checkBox = checkBoxes[i];
        if(checkBox.Checked) {
            checkedItems.Add(checkBox.Text);
        }
    }
    string result = String.Join(" ; ", checkedItems.ToArray());
