            void steelstandard_EditValueChanged(object sender, EventArgs e)
        {
            int[] selectedRows = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRows.Length; i++)
            {
                DataRow rowGridView1 = (gridView1.GetRow(selectedRows[i]) as DataRowView).Row;
                int length = Convert.ToInt32(rowGridView1["Long mm"]);
                if (Convert.ToInt32(steelstandard.EditValue) == 1)
                {
                    tolerance.Text = string.Empty;
                    tolerance.Text = ((length / 5000) + 2).ToString();
                }
                else
                {
                    tolerance.Text = string.Empty;
                    tolerance.Text = ((length / 10000) + 2).ToString();
                }
            }
        }
        steelstandard.EditValueChanged += steelstandard_EditValueChanged;
