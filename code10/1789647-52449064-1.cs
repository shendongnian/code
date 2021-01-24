    private void CalculateButton_Click(object sender, EventArgs e)
    {
    	foreach (DataGridViewRow row in dgvGrades.Rows)
    	{
    		if (decimal.TryParse(row.Cells["Grade1"]?.Value?.ToString(), out decimal Grade1)
    			&& decimal.TryParse(row.Cells["Grade2"]?.Value?.ToString(), out decimal Grade2))
    		{
    			var avg = (Grade1 + Grade2) / 2;
    			row.Cells["Average"].Value = avg;
    
    			if (avg < 74)
    			{
    				row.Cells["Remarks"].Value = "FAILED";
    			}
    			else
    			{
    				row.Cells["Remarks"].Value = "PASSED";
    			}
    		}
    	}
    }
