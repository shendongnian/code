    Table table = new Table();
    TableRow row1 = new TableRow();
    table.Rows.Add(row1);
    TableCell cell1 = new TableCell();
    TableCell cell2 = new TableCell();
    row1.Cells.Add(cell1);
    row1.Cells.Add(cell2);
    Label label1 = new Label();
    label1.Text = "Username:";
    cell1.Controls.Add(label1);
    TextBox textBox1 = new TextBox();
    textBox1.ID = "userNameTextBox";
    cell2.Controls.Add(textBox1);
    // and so on...
    myPlaceholder.Controls.Add(table);
