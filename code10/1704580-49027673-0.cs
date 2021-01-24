    DataGridViewButtonColumn tempBtnColumn = new DataGridViewButtonColumn();
    tempBtnColumn.HeaderText = "Button";
    tempBtnColumn.Text = "Button-Text";
    tempBtnColumn.Name = "Button-Name";
    tempBtnColumn.UseColumnTextForButtonValue = true;
    
    Grid.Columns.Add(tempBtnColumn);
    //or if you want a specified position for the Grid:
    Grid.Columns.Insert(0, tempBtnColumn);
