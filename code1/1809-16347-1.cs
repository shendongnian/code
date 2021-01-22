    UltraWebGrid uwgMyGrid = new UltraWebGrid();
    uwgMyGrid.Columns.Add("colTest", "Test Dropdown");
    uwgMyGrid.Columns.FromKey("colTest").Type = ColumnType.DropDownList;
    uwgMyGrid.Columns.FromKey("colTest").ValueList.ValueListItems.Insert(0, "ONE", "Choice 1");
    uwgMyGrid.Columns.FromKey("colTest").ValueList.ValueListItems.Insert(1, "TWO", "Choice 2");
