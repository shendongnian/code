    int index;
    bool parsed = Int32.TryParse(txtvalue.Text, out index);
    if (parsed)
    {
      dataGridView1.Rows(index).Selected = True
    }
    
