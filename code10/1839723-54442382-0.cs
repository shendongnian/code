    List<string> selectedValues = new List<string>();
    foreach (object item in CheckBoxList1.Items) {
        var listItem = (ListItem)item;
        if (listItem.Selected) {
           selectedValues.Add(listItem.Value);
        }
     }
