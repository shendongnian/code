    public DataTable GetImproperRecords(DataTable ProperRecords, DataTable ImproperRecords) {
      DataTable relatedTable = new DataTable("Difference");
      try {
         using (DataSet dataSet = new DataSet()) {
            dataSet.Tables.AddRange(new DataTable[] { ProperRecords.Copy(), ImproperRecords.Copy() });
            DataColumn properColumn = new DataColumn();
            properColumn = dataSet.Tables[0].Columns[1]; // Assuming subsNumber is at index 1
            DataColumn improperColumn = new DataColumn();
            improperColumn = dataSet.Tables[1].Columns[0]; // Assuming subsNumber is at index 0
            //Create DataRelation
            DataRelation relation = new DataRelation(string.Empty, properColumn, improperColumn, false);
            dataSet.Relations.Add(relation);
            //Create columns for return relatedTable
            for (int i = 0; i < ImproperRecords.Columns.Count; i++) {
               relatedTable.Columns.Add(ImproperRecords.Columns[i].ColumnName, ImproperRecords.Columns[i].DataType);
            }
            relatedTable.BeginLoadData();
            foreach (DataRow parentrow in dataSet.Tables[1].Rows) {
               DataRow[] childrows = parentrow.GetChildRows(relation);
               if (childrows != null && childrows.Length > 0)
                  relatedTable.LoadDataRow(parentrow.ItemArray, true);
            }
            relatedTable.EndLoadData();
         }
      }
      catch (Exception ex) {
         Console.WriteLine(ex.Message);
      }
      return relatedTable;
    }
