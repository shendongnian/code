        ...
        lv.OwnerDraw = true;
        lv.DrawItem += new DrawListViewItemEventHandler( lv_DrawItem );
        ...
    void lv_DrawItem( object sender, DrawListViewItemEventArgs e )
    {
        Rectangle foo = e.Bounds;
        foo.Offset( -10, 0 );
        e.Graphics.FillRectangle( new SolidBrush( e.Item.BackColor ), foo );
        e.DrawDefault = true;
    }
