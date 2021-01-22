    using System.Drawing.Font;
    
    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    		{
    
    			if(((DataGridView)sender).SelectedCells.Count > 0)
    			{
    				((DataGridView) sender).SelectedCells[0].Style = new DataGridViewCellStyle()
    				                                                 	{
    				                                                 		BackColor = Color.White,
    				                                                 		Font = new Font("Tahoma", 8F),
    				                                                 		ForeColor = SystemColors.WindowText,
    				                                                 		SelectionBackColor = Color.Red,
    				                                                 		SelectionForeColor = SystemColors.HighlightText
    				                                                 	};
    			}
    		}
