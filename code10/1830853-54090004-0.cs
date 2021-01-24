    private static DataTable GetDataTabletFromCSVFile1(string csv_file_path1)
      {
    
       DataTable table2 = new DataTable("Real");
    
       try
       {
        using (TextFieldParser csvReader1 = new TextFieldParser(csv_file_path1))
        {
         csvReader1.SetDelimiters(new string[] { "," });
         csvReader1.HasFieldsEnclosedInQuotes = true;
         string[] colFields = csvReader1.ReadFields();
    
         foreach (string column in colFields)
         {
          DataColumn datecolumn2 = new DataColumn(column);
          datecolumn2.AllowDBNull = true;
          table2.Columns.Add(datecolumn2);
         }
    
         while (!csvReader1.EndOfData)
         {
          string[] fieldData1 = csvReader1.ReadFields();
          table2.Rows.Add(fieldData1);
         }
        }
    
        foreach (DataRow dr in table2.Rows)
        {
         foreach (DataColumn dc in table2.Columns)
         {
          if (string.IsNullOrEmpty(dr[dc.ColumnName].ToString()))
          {
           dr[dc.ColumnName] = DBNull.Value;
          }
         }
        }
    
       }
       catch (Exception ex)
       {
        MessageBox.Show("Select New File");
       }
    
       return table2;
    
      }
