    //foreach (DataRow dr in dt.Rows)
    //{
    //    img = Image.FromFile(@dr["image"].ToString());
    //    foodListView.Rows[i].Cells["image"].Value = img;
    //    i++;
    //}
    foodListView.CellFormatting += foodListView_CellFormatting;
     private void foodListView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (foodListView.Columns[e.ColumnIndex].Name == "image")
            {
                e.Value = Bitmap.FromFile(e.Value.ToString());
                e.FormattingApplied = true;
            }
        }
