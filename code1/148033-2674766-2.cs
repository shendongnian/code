    // Testing Cell Data Type via C# 4.0    
    object value = worksheet.Cells[1,1].Value;    
    string typeName;
    
    if (value == null)
    {
        typeName = "null";
    }
    else
    {
        typeName = value.GetType().ToString();
    }
    
    MessageBox.Show("The value held by the cell is a '" + typeName + "'");
