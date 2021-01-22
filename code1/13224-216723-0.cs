    // the index of the current hot-tracking tab
    private int hotTrackTab = -1;
    // returns the index of the tab under the cursor, or -1 if no tab is under
    private int GetTabUnderCursor()
    {
        Point cursor = this.tabs.PointToClient( Cursor.Position );
        for( int i = 0; i < this.tabs.TabPages.Count; i++ )
        {
            if( this.tabs.GetTabRect( i ).Contains( cursor ) )
                return i;
        }
        return -1;
    }
    // updates hot tracking based on the current cursor position
    private void UpdateHotTrack()
    {
        int hot = GetTabUnderCursor();
        if( hot != this.hotTrackTab )
        {
            // invalidate the old hot-track item to remove hot-track effects
            if( this.hotTrackTab != -1 )
                this.tabs.Invalidate( this.tabs.GetTabRect( this.hotTrackTab ) );
            this.hotTrackTab = hot;
            // invalidate the new hot-track item to add hot-track effects
            if( this.hotTrackTab != -1 )
                this.tabs.Invalidate( this.tabs.GetTabRect( this.hotTrackTab ) );
            // force the tab to redraw invalidated regions
            this.tabs.Update();
        }
    }
    private void tabs_DrawItem( object sender, DrawItemEventArgs e )
    {
        // draw the background based on hot tracking
        if( e.Index == this.hotTrackTab )
        {
            using( Brush b = new SolidBrush( Color.Yellow ) )
                e.Graphics.FillRectangle( b, e.Bounds );
        }
        else
        {
            e.DrawBackground();
        }
        // draw the text label for the item, other effects, etc
    }
    private void tabs_MouseEnter( object sender, EventArgs e )
    {
        UpdateHotTrack();
    }
    private void tabs_MouseLeave( object sender, EventArgs e )
    {
        UpdateHotTrack();
    }
    private void tabs_MouseMove( object sender, MouseEventArgs e )
    {
        UpdateHotTrack();
    }
