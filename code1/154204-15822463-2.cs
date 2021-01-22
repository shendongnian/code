       private void cONTRACTERBindingSource_CurrentItemChanged(object sender, EventArgs e)
            {
                if (cONTRACTERDataGridView.Tag==null)
                {
                    DataRow ThisDataRow =
                    ((DataRowView)((BindingSource)sender).Current).Row;
                    if (ThisDataRow.RowState == DataRowState.Modified)
                        cONTRACTERDataGridView.Tag = "1";
                }
            }
