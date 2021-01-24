    for (int i = dataGridView2.SelectedRows.Count - 1; i >= 0; i--)
    { 
          dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[i].Index);
          ListOfPeople.RemoveAt(i);
    }
