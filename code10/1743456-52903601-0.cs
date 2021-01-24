    while (reader.Read())
    {
        var intt = int.Parse(textBox1.Text);                      
        var v1 = reader.GetValue(intt);
        var v2 = reader.GetValue(intt + 3);
        
        var fieldType1 = reader.GetFieldType(intt);
        var fieldType2 = reader.GetFieldType(intt + 3);
        var value1 = v1 == null ? null: Convert.ChangeType(v1, fieldType1);
        var value2 = v2 == null ? null: Convert.ChangeType(v2, fieldType2);
        
        listBox1.Items.Add(value1?.ToString() ?? string.Empty); 
        listBox2.Items.Add(value2?.ToString() ?? string.Empty);
    }
