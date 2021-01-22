    ListDictionary ld = new ListDictionary();
    foreach (DataColumn dc in dTable.Columns)
    {
         MessageBox.Show(dTable.Rows[0][dc].ToString());
         
         string value;
         if (int.TryParse(dTable.Rows[0][dc].ToString(), out QuantityInt))
               value = "integer";
         else if(double.TryParse(dTable.Rows[0][dc].ToString(), out QuantityDouble))
               value="double";
          else
               value="nvarchar";
         ld.Add(dc.ColumnName, value);
    }
