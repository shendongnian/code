    private void myComboBox_DrawItem(object sender, DrawItemEventArgs e)
    		{
    			if ( boundDataSource.Count > 0 && e.Index >= 0 )
    			{
    			  if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
    				{
    					//Get the data here
    					string dataToShow=  GetDataToShow()
    
    					e.DrawFocusRectangle();
    
    					System.Drawing.Graphics g = e.Graphics;
    					Rectangle r = e.Bounds;				
    
    				
    					e.Graphics.FillRectangle(new SolidBrush(Color.Blue), r);
    					g.DrawStringdataToShow, e.Font, Brushes.White, r, stringFormat);
    					e.DrawFocusRectangle();
    					g.Dispose();
    				}
    				
    
    				
    			}
    		}
 
