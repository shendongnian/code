    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        // This event is called once for each tab button in your tab control
        // First paint the background with a color based on the current tab
 
       // e.Index is the index of the tab in the TabPages collection.
        switch (e.Index )
        {
            case 0:
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                break;
            case 1:
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
                break;
            default:
                break;
        }
        // Then draw the current tab button text 
        Rectangle paddedBounds=e.Bounds;
        paddedBounds.Inflate(-2,-2);  
        e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
     
    }
