        protected void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            /// .. perform actions according to keyboard events ..
            /// .. for example below one ..
        }
        public override void UpdateAfterEditGrid(DataSet ds, DataGridView dataGridView1, bool DoRestoreCursor)
        {
        if (daGrid != null)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            dataGridView1.EndEdit();
            try
            {
                if (ds == null)
                {
                    //DataGridView dgv = dataGridView1;
                    //Console.WriteLine("Go datasource update .. " + dgv[cColumnIndex, cRowIndex].Value);
                    daGrid.Update((DataTable)dataGridView1.DataSource);
                }
                else daGrid.Update(ds);
                LoadGridRestoreCursor(dataGridView1, DoRestoreCursor);
            }
            catch { ErrorReporting.ErrorMessage("== cannot update this content =="); }
        }
    }
 
