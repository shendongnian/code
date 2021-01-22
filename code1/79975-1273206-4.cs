        public void CheckRows()
        {
           MyPersonDS tmpPersonDS = new MyPersonDS();
            // Load Person info
           using (var tmpPersonDT = tmpPersonDS.PersonDT)
           {
               foreach (MyPersonRow row in tmpPersonDT.Rows)
               {
                   CheckPersonData(row);
               }
           }
        }
        public void CheckPersonData(MyPersonRow row)
        {
            // If DataBinding is used, then show if the row is unchanged / modified / new...
            System.Diagnostics.Debug.WriteLine("Row State: " + row.RowState.ToString());
            System.Diagnostics.Debug.WriteLine("Row Changes:");
            System.Diagnostics.Debug.WriteLine(BuildRowChangeSummary(row));
            // If not DataBound then update the strongly-types Row properties
            row.ResidencyCountyID = lkuResidencyCountyId.EditValue;
        
        }
        public string BuildRowChangeSummary(DataRow row)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            int rowColumnCount = row.Table.Columns.Count;
            for (int index = 0; index < rowColumnCount; ++index)
            {
                result.Append(string.Format("Original value of {0}: {1}\r\n", row.Table.Columns[index].ColumnName, row[index, DataRowVersion.Original]));
                result.Append(string.Format("Current  value of {0}: {1}\r\n", row.Table.Columns[index].ColumnName, row[index, DataRowVersion.Current]));
                if (index < rowColumnCount - 1) { result.Append("\r\n"); }
            }
            return result.ToString();
        }
