      void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
      {
         if (e.ColumnIndex == 0) // dtxtPercentageOfUsersAllowed.Index
         {
            TextBox tx = dgvImpRDP_InfinityRDPLogin.EditingControl as TextBox;
            if (tx != null)
            {
               double percentage;
               object actual_value = tx.Text;
               if (actual_value.GetType() == typeof(double))
               {
                  percentage = (double)dgvImpRDP_InfinityRDPLogin[e.ColumnIndex, e.RowIndex].Value;
               }
               else if (!double.TryParse(actual_value.ToString(), out percentage))
               {
                  e.Cancel = true;
                  dgvImpRDP_InfinityRDPLogin[e.ColumnIndex, e.RowIndex].ErrorText = "The value must be between 0 and 1";
                  return;
               }
               if (percentage < 0 || percentage > 1)
               {
                  e.Cancel = true;
                  dgvImpRDP_InfinityRDPLogin[e.ColumnIndex, e.RowIndex].ErrorText = "The value must be between 0 and 1";
               }
               else
               {
                  dgvImpRDP_InfinityRDPLogin[e.ColumnIndex, e.RowIndex].ErrorText = null;
               }
            }
         }
      }
