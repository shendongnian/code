        //Populate the Datatable with the Lookup lists
        private DataTable typeDataTable(DataGridView dataGridView, Lookup<string, Element> type_Lookup, Dictionary<Element, string> type_dictionary, string strNewStyle, string strOldStyle, string strID, string strCount)
        {
            int row = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add(strOldStyle, typeof(string));
            dt.Columns.Add(strID, typeof(string));
            dt.Columns.Add(strCount, typeof(int));
            dt.Columns.Add("combobox", typeof(DataGridViewComboBoxCell));
            //Add All Doc Types to ComboBoxes
            DataGridViewComboBoxCell CmBx = new DataGridViewComboBoxCell();
            CmBx.DataSource = new BindingSource(type_dictionary, null);
            CmBx.DisplayMember = "Value";
            CmBx.ValueMember = "Key";
            //Add Style Comboboxes
            DataGridViewComboBoxColumn Data_CmBx_Col = new DataGridViewComboBoxColumn();
            Data_CmBx_Col.HeaderText = strNewStyle;
            dataGridView.Columns.Add(addDataGrdViewComboBox(Data_CmBx_Col, type_dictionary));
            setCellComboBoxItems(dataGridView, 1, 3, CmBx);
            //Add style Rows
            foreach (IGrouping<string, Element> StyleGroup in type_Lookup)
            {
                row++;
                //Iterate through each group in the Igrouping
                //Add Style Rows
                dt.Rows.Add(StyleGroup.Key, row, StyleGroup.Count().ToString());
     
            }
            return dt;
        }
        private void setCellComboBoxItems(DataGridView dataGrid, int rowIndex, int colIndex, DataGridViewComboBoxCell CmBx)
        {
            DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)dataGrid.Rows[rowIndex].Cells[colIndex];
            // You might pass a boolean to determine whether to clear or not.
            dgvcbc.Items.Clear();
            foreach (DataGridViewComboBoxCell itemToAdd in CmBx.Items)
            {
                dgvcbc.Items.Add(itemToAdd);
            }
        
