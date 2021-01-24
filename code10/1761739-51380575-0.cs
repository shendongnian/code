    DataRow datarow3= _longDataTable.NewRow();
      datarow3.ItemArray = drlibrary.ItemArray;
       datarow3["VariableTableCode"] = reader.tostring(0);
       datarow3["VariableRowCode"] = reader.tostring(1);
       datarow4["VariableColumnCode"] = reader.tostring(2);
        _longDataTable.Rows.Add(datarow3);
           // you may need to encrement the row name variable. 
       }
