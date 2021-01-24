        private void HideColumns(DataGridView datagridview)
        {
            try
            {
                datagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;
                for (int i = 0; i < datagridview.Columns.Count; i++)
                {
                    var column = datagridview.Columns[i];
                    var itemType = datagridview.Rows[(int)OrdersAndComponentsRows.ItemType].Cells[column.Index].Value.ToString();
                    if (itemType == Glossary.IndirectCOType)
                        column.Visible = IndirectCOCheckBox.Checked;
                    else if (itemType == Glossary.NotAllocatedType)
                        column.Visible = NotAllocatedCheckBox.Checked;
                    else
                        column.Visible = DirectCOCheckBox.Checked;
                }
            }
            finally
            {
                datagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }
