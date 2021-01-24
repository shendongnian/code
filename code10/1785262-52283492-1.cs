     private void TB_FirstName_TextChanged(object sender, EventArgs e)
    {
    	if (!string.IsNullOrWhiteSpace(TB_FirstName.Text))
    		{
    			(DGV_SearchResult.DataSource as DataTable).DefaultView.RowFilter = string.Format("NAM LIKE '%{0}%'", TB_FirstName.Text);
    		}
    	else
    		{ 
               // Load data again
    		}
    }
