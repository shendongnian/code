    public static void ActOnCheckedRows(this GridView gridView, string checkBoxId, Action<IEnumerable<int>> action)
    {
       var checkedRows = from GridViewRow msgRow in gridView.Rows
                         where ((CheckBox)msgRow.FindControl(checkBoxId)).Checked
                         select (int) gridView.DataKeys[msgRow.RowIndex].Value;
        action(checkedRows);
    }
