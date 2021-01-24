       public DataTable DataTableDataTransformer(DataTable original, string[] columns, string maskedValue)
       {
            // get column indices
            int[] columnIndices = columns.Select(col => original.Columns.IndexOf(col))
                                          .Where(i => i >= 0)
                                          .ToArray();
            // clone original table structure
            var retVal = original.Clone();
            // change datatype of the columns in cloned table
            foreach (var index in columnIndices)
                retVal.Columns[index].DataType = typeof(string);
            //add data to new table
            foreach(DataRow row in original.Rows)
            {
                var values = row.ItemArray;
                foreach (var index in columnIndices)
                    values[index] = maskedValue;
                retVal.Rows.Add(values);
            }
            return retVal;
        }
