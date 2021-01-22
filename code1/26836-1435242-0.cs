            DataSet newDset = srcTable.Clone();
            DataTable dTable = newDset.Tables[0];
            for (int j = 0; j < dTable.Columns.Count; j++)
            {
                if (dTable.Columns[j].DataType.ToString() == "System.DateTime")
                {
                    dTable.Columns[j].DateTimeMode = DataSetDateTime.Utc;
                }
            }
