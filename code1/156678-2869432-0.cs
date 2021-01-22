    List<int> listOfMinutes = new List<int>();
    
    for (int i = 0;i < dataGridView1.Rows.Count; i++)
    {
        // either ".Text" or ".Value"...can't remember
        listOfMinutes.Add(int.Parse(dataGridView1.Rows[i].Cells[7].Text));
    }
