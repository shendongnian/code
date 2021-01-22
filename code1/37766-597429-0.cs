        private void SetColumnWidth(int columnID, int width)
        {
            // add table style if first call
            if (this.dataGrid1.TableStyles.Count == 0)
            {
                // Set the DataGridTableStyle.MappingName property
                // to the table in the data source to map to.
                dataGridColumnTableStyle.MappingName = 
                                 "<name of your table in the DS here>";
                // Add it to the datagrid's TableStyles collection
                this.dataGrid1.TableStyles.Add
                     (dataGridColumnTableStyle);
            }
            // set width
            this.dataGrid1.TableStyles[0].GridColumnStyles[columnID].Width 
                 = width;
        }
