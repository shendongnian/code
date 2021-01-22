    public static void MakeReadOnly(this ComboBox pComboBox) {
       if (pComboBox.SelectedItem == null)
          return;
       pComboBox.DataSource = new List<object> {
          pComboBox.SelectedItem
       };
    }
