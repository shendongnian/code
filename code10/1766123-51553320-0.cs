    private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
                if (dataGridView2.IsCurrentCellDirty)
                {
                    dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
