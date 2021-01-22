    using System.Drawing.Font;
    
    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    		{
    
    			foreach(DataGridViewCell cell in ((DataGridView)sender).SelectedCells)
			{
				cell.Style = new DataGridViewCellStyle()
				{
					BackColor = Color.White,
					Font = new Font("Tahoma", 8F),
					ForeColor = SystemColors.WindowText,
					SelectionBackColor = Color.Red,
					SelectionForeColor = SystemColors.HighlightText
				};
			}
    		}
