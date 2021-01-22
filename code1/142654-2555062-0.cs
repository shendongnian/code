    /// <summary>
    /// Handles the DrawItem event of the listBox1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.DrawItemEventArgs"/> instance containing the event data.</param>
    private void listBox1_DrawItem( object sender, DrawItemEventArgs e )
    {
       e.DrawBackground();
       Graphics g = e.Graphics;
    
        // draw the background color you want
        // mine is set to olive, change it to whatever you want
        g.FillRectangle( new SolidBrush( Color.Olive), e.Bounds );
    
        // draw the text of the list item, not doing this will only show
        // the background color
        // you will need to get the text of item to display
        g.DrawString( THE_LIST_ITEM_TEXT , e.Font, new SolidBrush( e.ForeColor ), new PointF( e.Bounds.X, e.Bounds.Y) );
    
        e.DrawFocusRectangle();
    }
