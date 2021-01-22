        public void FillFromList(List<T> col)
        {
            Type elementType = typeof(T);
            // Nested query of generic element list of property
            // values (using a join to the DataTable columns)
            var rows = from row in col
                       select new
                       {
                           Fields = from column in m_dataTable.Columns.Cast<DataColumn>()
                                    join prop in elementType.GetProperties()
                                      on column.Caption equals prop.Name
                                    select prop.GetValue(row, null)
                       };
            // Add each row to the DataTable
            int recordCount = 0;
            foreach ( var entry in rows )
            {
                m_dataTable.Rows.Add(entry.Fields.ToArray());
            }
