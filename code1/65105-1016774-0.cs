        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tb.Text == "")
            {
                //Unfilter the data
                gv.DataSource = dtb;
                return;
            }
            //Get default view of your data table and filter
            DataView dv = dtb.DefaultView;
            //Suppose your column name is "Value"
            dv.RowFilter = "Value like '" + tb.Text + "%'";
            gv.DataSource = dv;
        }
