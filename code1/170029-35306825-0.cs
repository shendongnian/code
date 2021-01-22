    private void dgvGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
          if (dgvGrid.CurrentCell.ColumnIndex == 0 || dgvGrid.CurrentCell.ColumnIndex == 2)
              {
               if (e.Control is TextBox)
                  {
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
                  }
              }
        }
