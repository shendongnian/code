      void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
      {
         if (e.ColumnIndex == 0) // dtxtPercentageOfUsersAllowed.Index
         {
            object should_be_new_value = e.FormattedValue;
            double percentage;
            if (dgvImpRDP_InfinityRDPLogin.EditingControl != null)
            {
               string text = dgvImpRDP_InfinityRDPLogin.EditingControl.Text;
               if (!double.TryParse(text, out percentage))
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
