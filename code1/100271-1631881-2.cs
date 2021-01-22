    private void radGvReviews_CellDoubleClick(object sender, GridViewCellEventArgs e)
    {
         GridViewComboBoxColumn combo = radGvReviews.Columns[e.ColumnIndex] is GridViewComboBoxColumn);
         if (combo != null)
         {
                  MessageBox.Show(combo.DisplayName);
         }
    }
