    // Testing Cell Data Type via C# 3.0
    object value = (worksheet.Cells[1, 1] as Excel.Range).get_Value(Type.Missing);
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
