    Dim IsLocationCounter As Integer
    If (Not pds Is Nothing AndAlso pds.Tables.Count > 0 AndAlso pds.Tables[0].Rows.Count > 0) Then
      
      /* I can't remember here if you can use <> or if you have to use Is */
      If (pds.Tables[0].Columns[0].ColumnName[1] <> DBValue.Null) Then
        
        /* Because you pass an integer by reference to TryParse, you don't have to set anything in an else statement */
        If ( Not Integer.TryParse(pds.Tables[0].Columns[0].ColumnName[1].ToString(), IsLocationcounter) ) Then
          Throw New Exception ("Do some error handling here because there is no int coming back in your dataset")
        End If
      End If
    End If
