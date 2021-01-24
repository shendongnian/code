    SqlCommand queryLocal = new SqlCommand("SELECT DISTINCT *uniqueField* FROM myTable");
    var reader = queryLocal.ExecuteReader();
    
    List<string> uniqueFields = new List<string>();
    while (reader.Read())
        uniqueFields.Add(reader[0]);
    reader.Close();
    
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        if (uniqueFields.Contains(dataGridView1.Rows[i])
        {
            dataGridView1.Rows.RemoveAt(i);
            i--;
        }
    }
