    private void DropDown_MouseLeave( object sender, EventArgs e ) {
        Point pnt = Cursor.Position;
        if( rgn.IsVisible( pnt ) == false ) {
            rgn.MakeEmpty();
            contextMenuStrip1.Close();
        }
    }
