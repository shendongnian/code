    private void lbReports_DrawItem(object sender, DrawItemEventArgs e)
    		{
    			e.DrawBackground();
    
    			bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
    
    			int index = e.Index;
    			if (index >= 0 && index < lbReports.Items.Count)
    			{
    				string text = lbReports.Items[index].ToString();
    				Graphics g = e.Graphics;
    
    				Color color = (selected) ? Color.FromKnownColor(KnownColor.Highlight) : (((index % 2) == 0) ? Color.White : Color.Gray);
    				g.FillRectangle(new SolidBrush(color), e.Bounds);
    
    				// Print text
    				g.DrawString(text, e.Font, (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush, 
    					lbReports.GetItemRectangle(index).Location);
    			}
    
    			e.DrawFocusRectangle();
    		}
