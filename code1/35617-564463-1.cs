    // Make owner-drawn to be able to give different alignments to single subitems
    lvResult.OwnerDraw = true;
    ...
    // Handle DrawSubItem event
    private void lvResult_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        // This is the default text alignment
        TextFormatFlags flags = TextFormatFlags.Left;
        // Align text on the right for the subitems after row 11 in the 
        // first column
        if (e.ColumnIndex == 0 && e.Item.Index > 11)
        {
            flags = TextFormatFlags.Right;
        }
        e.DrawText(flags);
    }
    // Handle DrawColumnHeader event
    private void lvResult_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        // Draw the column header normally
        e.DrawDefault = true;
        e.DrawBackground();
        e.DrawText();
    }
