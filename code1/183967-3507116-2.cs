    if (e.RowIndex < 0 || e.ColumnIndex != dataGridView.Columns["CustomList"].Index)
                return;
    //get the name of this column
    string name = (string)dataGridView[dataGridView.Columns["Name"].Index, e.RowIndex].Value;
    var myClassObject= myClassList.Find(o => o.Name == name);
    MyHelper.EditValue(this, myClassObject, "CustomList");
