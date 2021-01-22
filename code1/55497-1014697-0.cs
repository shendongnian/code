DataView view  = locations.Tables[0].DefaultView;
view.Sort      = "locationName";
Table table = new Table();
locationTablePlaceHolder.Controls.Clear();
locationTablePlaceHolder.Controls.Add(table);
// enumerator to loop through all items in the DataView
IEnumerator enumerator = view.GetEnumerator();
enumerator.Reset();
// first create all the row objects since we want to populate
// column by column.
int rowCount = 5;
int colCount = 5;
for (int i = 0; i < rowCount; i++)
{
    TableRow row = new TableRow();
    table.Rows.Add(row);
}
// then loop through each column taking items from the enumerator
// to populate the table
for (int j = 0; j < colCount; j++)
{
    for (int i = 0; i < rowCount; i++)
    {
        TableCell cell = new TableCell();
        if (enumerator.MoveNext())
        {
            Label label = new Label();
            label.Text = (String)((DataRowView)enumerator.Current).Row["locationName"];
            cell.Controls.Add(label);
            table.Rows[i].Cells.Add(cell);
        }
    }
}
</pre>
