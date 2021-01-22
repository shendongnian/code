        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1)
            {
                return;
            }
            if(e.Row.Cells[YOUR_COLUMN_INDEX].Text=="NO"){
                 e.Row.BackColor=Color.Red;   
            }
        }
