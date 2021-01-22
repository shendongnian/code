        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {            
            Int32 colIndex = Convert.ToInt32(e.Column.ToString());
            lv.Columns[colIndex].Text = "new text";
        }
