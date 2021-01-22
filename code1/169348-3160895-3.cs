    var query1 = from t in table1 ...
    var query2 = from t in table2 ...
    var finalQuery = CreateEmptyEnumerable(query1);
    
    if (Checkbox1.Checked)
    {
        finalQuery = query1;
    }
    
    if (Checkbox2.Checked)
    {
        finalQuery = finalQuery.Union(query2);
    }
    
    DataGridView1.DataSource = finalQuery.ToList(); // to avoid re-enumeration
