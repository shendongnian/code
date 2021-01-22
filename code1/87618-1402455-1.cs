    foreach( DataTable curTable in myDataSet.Tables )
    {
         foreach( DataRow curRow in curTable.Rows )
         {
              foreach( DataColumn curCol in Table.Columns )
              {
                   object item = curRow[ curCol ];
              }
         }
    }
