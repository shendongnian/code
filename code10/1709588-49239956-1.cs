    ComboBox1.SelectedItem = ComboBox.SelectedItem.Where(
      ComboBox => ComboBox.SelectedItem == productList[0].ProductName.ToString());
    //and
    ComboBox1.SelectedItem = DB_SelectorList.Where(
      DB_SelectorList => DB_SelectorList.ProductName == productList[0].ProductName.ToString());
